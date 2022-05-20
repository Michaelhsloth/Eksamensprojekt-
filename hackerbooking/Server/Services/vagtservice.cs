using Dapper;
using hackerbooking.Server.Connector;
using hackerbooking.Shared;
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
        public List<OpgaverDTO> GetOpgaver()
        {
            var sql = "SELECT * FROM opgaver";
            using (var connection = connector.Connect())
            {
                var OpgaveList = connection.Query<OpgaverDTO>(sql);
                //Console.WriteLine("service nået");
                return OpgaveList.ToList<OpgaverDTO>();
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

        public async Task DeleteOpgave(int id)
        {
            var parameters = new { ID = id };
            var sql = "DELETE FROM opgaver WHERE opgid = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
                //Console.WriteLine("service nået");   

            }
        }
        public async Task postVagt(TestDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave, START = vagt.start, SLUT = vagt.slut };
            var sql = "INSERT INTO vagter (opgave, start, slut) VALUES (@OPGAVE, @START, @SLUT)";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task NyOpgave(OpgaverDTO opgave)
        {
            var parameters = new { OPGAVE = opgave.opgnavn };
            var sql = "INSERT INTO opgaver (opgnavn) VALUES (@OPGAVE)";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task putVagt(TestDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave, START = vagt.start, SLUT = vagt.slut, ID = vagt.id };
            //Console.WriteLine($"{vagt.navn},{vagt.id},{vagt.tal}");
            var sql = "UPDATE vagter SET opgave = @OPGAVE, start = @START, slut = @SLUT WHERE id = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}