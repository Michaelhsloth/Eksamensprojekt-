using Dapper;
using hackerbooking.Server.Connector;
using hackerbooking.Shared;

namespace hackerbooking.Server.Services
{
    public class LoginService
    {
        private readonly DapperConnector connector;

        public LoginService(DapperConnector _connector)
        {

            connector = _connector;
        }

        public List<FrivilligeDTO> Login(string Email, string Password)
        {
            var parameters = new { EMAIL = Email, PASSWORD = Password };
            var sql = "SELECT * FROM brugere WHERE email = @EMAIL AND password = crypt(@PASSWORD, password)";
            using (var connection = connector.Connect())
            {
                var FrivilligeList = connection.Query<FrivilligeDTO>(sql, parameters);
                Console.WriteLine("service nået" + parameters);
                return FrivilligeList.ToList();
            }
        }
    }
}