using Dapper;
using hackerbooking.Server.Connector;
using hackerbooking.Shared;

namespace hackerbooking.Server.Services
{
    public class OpgaverService
    {
        private readonly DapperConnector connector;

        public OpgaverService(DapperConnector _connector)
        {

            connector = _connector;
        }

        public List<OpgaverDTO> GetOpgaver()
        {
            var sql = "SELECT * FROM opgaver";
            using (var connection = connector.Connect())
            {
                var OpgaveList = connection.Query<OpgaverDTO>(sql);
                //Console.WriteLine("service nået");
                return OpgaveList.ToList();
            }
        }

        public async Task DeleteOpgave(int id)
        {
            var parameters = new { ID = id };
            var sql = "DELETE FROM opgaver WHERE opgave_id = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
                //Console.WriteLine("service nået");   

            }
        }

        public async Task NyOpgave(OpgaverDTO opgave)
        {
            var parameters = new { OPGAVE = opgave.opgave_navn };
            var sql = "INSERT INTO opgaver (opgave_navn) VALUES (@OPGAVE)";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}