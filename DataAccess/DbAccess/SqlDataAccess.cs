﻿using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    //talks to sql through dapper
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure,
                                                         U parameters,
                                                         string connectionId = "Default")
        {
            //get the connectionstring, create a sql connection and store it in "connection" then shut down the connection
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure,
                                                  parameters,
                                                  commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure,
                                      T parameters,
                                      string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure,
                                          parameters,
                                          commandType: CommandType.StoredProcedure);
        }
    }
}
