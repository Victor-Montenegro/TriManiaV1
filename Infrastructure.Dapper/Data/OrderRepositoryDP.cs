using Core.Interfaces;
using Core.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Dapper.Data
{
    public class OrderRepositoryDP : BaseRepositoryDP, IOrderRepositoryDP
    {
        public OrderRepositoryDP() : base() { }

        public async Task<OrderModel> GetOrderOpen(int userId)
        {
            try
            {
                OrderModel orderModel = new OrderModel();

                await using var connection = new MySqlConnection(ConnectionString);

                string query = @"SELECT 
	                                O.Id,
                                    O.UserId,
	                                O.TotalValue,
                                    O.Status,
                                    O.type,
                                    O.CreateDate
                                FROM
	                                `Order` AS O
                                WHERE
	                                O.UserId = @userId AND
                                    O.Status IN(0,1) AND
                                    O.DeletionDate IS NULL;
    
                                    SELECT 
                                    OT.Id,
                                    OT.ProductId,
                                    OT.Price,
                                    OT.Quantity,
                                    OT.CreateDate,
                                    OT.OrderId
                                FROM
	                                OrderItem AS OT
                                    INNER JOIN `Order` AS O ON OT.OrderId = O.Id
                                WHERE
	                                O.UserId = @userId AND
                                    O.Status IN(0,1) AND
                                    O.DeletionDate IS NULL AND
                                    OT.DeletionDate IS NULL;";

                var mult = await connection.QueryMultipleAsync(query, new { userId });

                orderModel = mult.Read<OrderModel>().SingleOrDefault();

                if(!(orderModel is null))
                    orderModel.Items = mult.Read<OrderItemModel>().ToList();

                return orderModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SalesReportModel> GetSalesReport(string initialDate, string finishDate, List<int> status, List<int> users)
        {
            try
            {
                SalesReportModel salesReport;
                List<OrderItemModel> orderItemModels;
                await using var connection = new MySqlConnection(ConnectionString);

                string query = @"SELECT 
                                    COUNT(FinishedDate) as finished_orders_amount,
                                    COUNT(CancelDate) as cancelled_orders_amount,
                                    SUM(TotalValue) as orders_total_value
                                 FROM
                                    `Order`
                                 WHERE
                                    UserId IN @users AND
                                    Status IN @status AND
                                    CreateDate > @initialDate AND 
                                    CreateDate < @finishDate AND
                                    DeletionDate IS NULL;

                                SELECT
                                    Id,
                                    UserId,
                                    TotalValue,
                                    Status,
                                    Type,
                                    CancelDate,
                                    FinishedDate,
                                    CreateDate
                                 FROM
                                    `Order`
                                 WHERE
                                    UserId IN @users AND
                                    Status IN @status AND
                                    CreateDate > @initialDate AND 
                                    CreateDate < @finishDate AND
                                    DeletionDate IS NULL;

                                SELECT 
                                    OT.Id,
                                    OT.ProductId,
                                    OT.Price,
                                    OT.Quantity,
                                    OT.CreateDate,
                                    OT.OrderId
                                FROM
	                                OrderItem AS OT
                                    INNER JOIN `Order` AS O ON OT.OrderId = O.Id
                                WHERE
	                                O.UserId IN @users AND
	                                O.Status IN @status AND
	                                O.CreateDate > @initialDate AND 
	                                O.CreateDate < @finishDate AND
	                                O.DeletionDate IS NULL AND 
	                                OT.DeletionDate IS NULL;";

                var mult = await connection.QueryMultipleAsync(query, new { users, initialDate, finishDate, status });

                salesReport = mult.Read<SalesReportModel>().SingleOrDefault();
                salesReport.Orders = mult.Read<OrderModel>().ToList();
                orderItemModels = mult.Read<OrderItemModel>().ToList();

                foreach (var order in salesReport.Orders)
                    order.Items.AddRange(orderItemModels.Where(x => x.OrderId == order.Id).ToList());

                return salesReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
