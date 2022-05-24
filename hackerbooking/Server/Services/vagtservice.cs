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
        public List<VagterDTO> getVagter()
        {
            var sql = "SELECT * FROM vagter";
            using (var connection = connector.Connect())
            {
                var vagtList = connection.Query<VagterDTO>(sql);
                //Console.WriteLine("service nået");
                return vagtList.ToList<VagterDTO>();
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
        public List<FrivilligeDTO> Login(string Email, string Password)
        {
            var parameters = new { EMAIL = Email, PASSWORD = Password };
            var sql = "SELECT * FROM frivillig WHERE email = @EMAIL AND password = crypt(@PASSWORD, password)";
            using (var connection = connector.Connect())
            {
                var FrivilligeList = connection.Query<FrivilligeDTO>(sql, parameters);
                Console.WriteLine("service nået" + parameters);
                return FrivilligeList.ToList<FrivilligeDTO>();
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
        public async Task postVagt(VagterDTO vagt)
        {
            var parameters = new { OPGAVE = vagt.opgave_navn, START = vagt.dato_tid_start, SLUT = vagt.dato_tid_slut };
            var sql = "INSERT INTO vagter (opgave_navn, dato_tid_start, dato_tid_slut) VALUES (@OPGAVE, @START, @SLUT)";
            using (var connection = connector.Connect())
            {
                await connection.ExecuteAsync(sql, parameters);
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
        public async Task PostFrivillig(FrivilligeDTO frivillig)
        {
            var parameters = new { TELEFON = frivillig.telefon_nummer, NAVN = frivillig.navn, EFTERNAVN = frivillig.efternavn, EMAIL = frivillig.email, KOMPETENCE = frivillig.kompetence, FØDSELSDAG = frivillig.fødselsdag, PASSWORD = frivillig.password  };
            var sql = "INSERT INTO frivillig (telefon_nummer, navn, efternavn, email, kompetence, fødselsdag, password) VALUES (@TELEFON, @NAVN, @EFTERNAVN, @EMAIL, @KOMPETENCE, @FØDSELSDAG, crypt(@PASSWORD, gen_salt('bf')))";
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
    }
}