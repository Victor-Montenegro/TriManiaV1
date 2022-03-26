using Core.Interfaces;
using Core.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Dapper.Data
{
    public class ProductRepositoryDP : BaseRepositoryDP, IProductRepositoryDP
    {
        public ProductRepositoryDP() : base() { }

        public async Task<IEnumerable<ProductModel>> GetAllProduts()
        {
            try
            {
                IEnumerable<ProductModel> products;

                string query = @"SELECT Id, Name, Description, Quantity, Price FROM Product WHERE DeletionDate IS NULL ";

                await using var connection = new MySqlConnection(ConnectionString);

                products = await connection.QueryAsync<ProductModel>(query);

                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
