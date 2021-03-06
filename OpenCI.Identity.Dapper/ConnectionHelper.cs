﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OpenCI.Identity.Dapper
{
    public class ConnectionHelper : IConnectionHelper
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public ConnectionHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["IdentityDb"].ConnectionString;
        }

        public ConnectionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection => _connection ?? (_connection = new SqlConnection(_connectionString));
    }
}