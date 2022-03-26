using Core.Interfaces;
using Core.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Dapper.Data
{
    public class UserRepositoryDP : BaseRepositoryDP, IUserRepositoryDP
    {

        public UserRepositoryDP() : base() { }

        public async Task<UserModel> GetById(int id)
        {
            try
            {
                UserModel user;

                await using var connection = new MySqlConnection(ConnectionString);

                string query = @"SELECT
                                    U.Id,
                                    U.Name,
                                    U.Login,
                                    U.Cpf,
                                    U.Email,
                                    U.BirthDay,
                                    A.Street,
                                    A.Neighborhood,
                                    A.Number,
                                    A.City,
                                    A.State,
                                    U.CreateDate
                                 FROM
                                    User AS U
                                    INNER JOIN Address AS A ON U.Id = A.UserId
                                WHERE 
                                    U.Id = @id AND
                                    U.DeletionDate IS NULL";

                user = await connection.QueryFirstAsync<UserModel>(query, new { id });

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserModel>> GetUserByFilters(string filter, int numberPage)
        {
            try
            {
                int page = numberPage * 10;
                IEnumerable<UserModel> users;

                string query = @"SELECT
                                U.Id,
                                U.Name,
                                U.Login,
                                U.Cpf,
                                U.Email,
                                U.BirthDay,
                                A.Street,
                                A.Neighborhood,
                                A.Number,
                                A.City,
                                A.State,
                                U.CreateDate
                             FROM
                                User AS U
                                INNER JOIN Address AS A ON U.Id = A.UserId
                             WHERE
                                U.Name = @filter OR 
                                U.Login = @filter OR 
                                U.Email = @filter AND
                                U.DeletionDate IS NULL
                             LIMIT 10 OFFSET @page";

                await using var connection = new MySqlConnection(ConnectionString);

                users = await connection.QueryAsync<UserModel>(query,new { filter, page });

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
