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

        public async Task<SalesReportModel> GetSalesReport(string initialDate, string finishDate, List<int> status, List<int> users)
        {
            try
            {
                SalesReportModel salesReport;
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
                                    DeletionDate IS NULL;";

                var mult = await connection.QueryMultipleAsync(query, new { users, initialDate, finishDate, status });

                salesReport = mult.Read<SalesReportModel>().SingleOrDefault();
                salesReport.Orders = mult.Read<OrderModel>().ToList();

                return salesReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
