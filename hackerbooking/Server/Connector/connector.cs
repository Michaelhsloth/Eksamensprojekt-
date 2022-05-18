using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace hackerbooking.Server.Connector
{
    public class DapperConnector
    {
        private readonly IConfiguration _configuration;
        private readonly string connString;
        public DapperConnector(IConfiguration configuration)
        {
            _configuration = configuration;
            connString = _configuration.GetConnectionString("NpgSql_Connection");
        }
        public IDbConnection Connect()
        {
            return new NpgsqlConnection(connString);

        }

    }
}