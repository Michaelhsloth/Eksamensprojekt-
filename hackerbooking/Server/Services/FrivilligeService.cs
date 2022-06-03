using Dapper;
using hackerbooking.Server.Connector;
using hackerbooking.Shared;

namespace hackerbooking.Server.Services
{
    public class FrivilligeService
    {
        private readonly DapperConnector connector;

        public FrivilligeService(DapperConnector _connector)
        {
            connector = _connector;
        }

        public List<FrivilligeDTO> GetFrivillige()
        {
            var sql = "SELECT * FROM brugere";
            using var connection = connector.Connect();
            var frivilligList = connection.Query<FrivilligeDTO>(sql);
            return frivilligList.ToList();
        }

        public List<FrivilligeDTO> FindFrivillig(int id)
        {
            var parameters = new { ID = id };
            var sql = "SELECT * FROM brugere WHERE frivillig_id = @id";
            using var connection = connector.Connect();
            var FrivilligeList = connection.Query<FrivilligeDTO>(sql, parameters);
            return FrivilligeList.ToList();
        }

        public async Task CreateFrivillig(FrivilligeDTO frivillig)
        {
            var parameters = new { TELEFON = frivillig.telefon_nummer, NAVN = frivillig.navn, EFTERNAVN = frivillig.efternavn, EMAIL = frivillig.email, KOMPETENCE = frivillig.kompetence, FØDSELSDAG = frivillig.fødselsdag, PASSWORD = frivillig.password, KOORDINATOR = frivillig.koordinator };
            //  Bruger Blowfish salt til at hashe password
            var sql = "INSERT INTO brugere (telefon_nummer, navn, efternavn, email, kompetence, fødselsdag, password, koordinator) VALUES (@TELEFON, @NAVN, @EFTERNAVN, @EMAIL, @KOMPETENCE, @FØDSELSDAG, crypt(@PASSWORD, gen_salt('bf')), @KOORDINATOR)";
            using var connection = connector.Connect();
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task UpdateFrivillig(int id, FrivilligeDTO frivillig)
        {
            var parameters = new { ID = id, EMAIL = frivillig.email, PASSWORD = frivillig.password };
            //  Bruger Blowfish salt til at hashe password
            var sql = "UPDATE brugere set email = @EMAIL, password = crypt(@PASSWORD, gen_salt('bf')) WHERE frivillig_id = @ID";
            using var connection = connector.Connect();
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}