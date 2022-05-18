using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.Threading.Tasks;
using System;
using System.Linq;
using hackerbooking.Shared;
using hackerbooking.Server.Connector;
//data acess service til vagter -- til implementation i controlleren 
//det her er man skriver sql queries til databasen 
namespace hackerbooking.Server.Services
{
    public class vagtService
    {
        private readonly DapperConnector connector;

        public vagtService(DapperConnector _connector)
        {

            connector = _connector;

        }
        public List<TestDTO> getVagter()
        {
            var sql = "SELECT * FROM vagter";
            using (var connection = connector.Connect())
            {
                var vagtList = connection.Query<TestDTO>(sql);
                //Console.WriteLine("service nået");
                return vagtList.ToList<TestDTO>();
            }
        }

        public async Task DeleteVagt(int id)
        {
            var parameters = new { ID = id };
            var sql = "DELETE FROM vagter WHERE id = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
                //Console.WriteLine("service nået");   

            }
        }

        public async Task postVagt(TestDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave, START = vagt.start };
            var sql = "INSERT INTO vagter (opgave, start) VALUES (@OPGAVE, @START)";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task putVagt(TestDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave, START = vagt.start, ID = vagt.id };
            //Console.WriteLine($"{vagt.navn},{vagt.id},{vagt.tal}");
            var sql = "UPDATE vagter SET opgave = @OPGAVE, start = @START WHERE id = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}