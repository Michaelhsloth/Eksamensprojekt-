using Dapper;
using hackerbooking.Server.Connector;
using hackerbooking.Shared;

namespace hackerbooking.Server.Services
{
    public class LoginService
    {
        // Dapper
        private readonly DapperConnector connector;

        public LoginService(DapperConnector _connector)
        {
            connector = _connector;
        }

        public List<FrivilligeDTO> FrivilligLogin(string Email, string Password)
        {
            var parameters = new { EMAIL = Email, PASSWORD = Password };
            // Tjekker om der er en bruger med den valgte email og password
            // Password er hashet
            var sql = "SELECT * FROM brugere WHERE email = @EMAIL AND password = crypt(@PASSWORD, password)";
            using var connection = connector.Connect();
            var FrivilligeList = connection.Query<FrivilligeDTO>(sql, parameters);
            return FrivilligeList.ToList();
        }
    }
}