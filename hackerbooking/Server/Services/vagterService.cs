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

        public List<VagterDTO> GetVagter()
        {
            var sql = "SELECT * FROM vagter";
            using (var connection = connector.Connect())
            {
                var vagtList = connection.Query<VagterDTO>(sql);
                return vagtList.ToList();
            }
        }

        public async Task DeleteVagt(int id)
        {
            var parameters = new { ID = id };
            var sql = "DELETE FROM vagter WHERE vagt_id = @ID";
            using var connection = connector.Connect();
            await connection.ExecuteAsync(sql, parameters);

        }

        public async Task CreateVagt(VagterDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave_navn, START = vagt.dato_tid_start, SLUT = vagt.dato_tid_slut };
            var sql = "INSERT INTO vagter (opgave_navn, dato_tid_start, dato_tid_slut) VALUES (@OPGAVE, @START, @SLUT)";
            using var connection = connector.Connect();
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task UpdateVagt(VagterDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave_navn, START = vagt.dato_tid_start, SLUT = vagt.dato_tid_slut, ID = vagt.vagt_id };
            var sql = "UPDATE vagter SET opgave_navn = @OPGAVE, dato_tid_start = @START, dato_tid_slut = @SLUT WHERE vagt_id = @ID";
            using var connection = connector.Connect();
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task TagVagt(int id, FrivilligeDTO frivillig)
        {
            var parameters = new { ID = id, FRIVILLIG = frivillig.frivillig_id };
            var sql = "UPDATE vagter set frivillig_id = @FRIVILLIG WHERE vagt_id = @id";
            using var connection = connector.Connect();
            await connection.ExecuteAsync(sql, parameters);

        }
    }
}