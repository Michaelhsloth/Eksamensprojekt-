using Dapper;
using hackerbooking.Server.Connector;
using hackerbooking.Shared;

namespace hackerbooking.Server.Services
{
    public class VagterService
    {
        private readonly DapperConnector connector;

        public VagterService(DapperConnector _connector)
        {
            connector = _connector;
        }

        public List<VagterDTO> getVagter()
        {
            var sql = "SELECT * FROM vagter";
            using (var connection = connector.Connect())
            {
                var vagtList = connection.Query<VagterDTO>(sql);
                //Console.WriteLine("service nået");
                return vagtList.ToList();
            }
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

        public async Task DeleteVagt(int id)
        {
            var parameters = new { ID = id };
            var sql = "DELETE FROM vagter WHERE vagt_id = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
                //Console.WriteLine("service nået");   

            }
        }

        public async Task postVagt(VagterDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave_navn, START = vagt.dato_tid_start, SLUT = vagt.dato_tid_slut };
            var sql = "INSERT INTO vagter (opgave_navn, dato_tid_start, dato_tid_slut) VALUES (@OPGAVE, @START, @SLUT)";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task putVagt(VagterDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave_navn, START = vagt.dato_tid_start, SLUT = vagt.dato_tid_slut, ID = vagt.vagt_id };
            //Console.WriteLine($"{vagt.navn},{vagt.id},{vagt.tal}");
            var sql = "UPDATE vagter SET opgave_navn = @OPGAVE, dato_tid_start = @START, dato_tid_slut = @SLUT WHERE vagt_id = @ID";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task TagVagt(int id, FrivilligeDTO frivillig)
        {
            var parameters = new { ID = id, FRIVILLIG = frivillig.frivillig_id };
            var sql = "UPDATE vagter set frivillig_id = @FRIVILLIG WHERE vagt_id = @id";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
                //Console.WriteLine("service nået");   

            }
        }
    }
}