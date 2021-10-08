using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data.SqlClient;
using System.Data;

namespace AssignmentApp.Data.Repository
{
    class ADbContext
    {
        public IDbConnection GetDataConnection()
        {
            string conn = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("CompanyDB");
            return new SqlConnection(conn);
        }
    }
}
