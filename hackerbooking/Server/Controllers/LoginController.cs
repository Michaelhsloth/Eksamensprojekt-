using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpGet("api/Login/Email{Email}Password{Password}")]
        public List<FrivilligeDTO> FrivilligLogin(string Email, string Password)
        {
            Console.WriteLine("api nået" + Email + Password);
            return _service.Login(Email, Password);
        }
    }
}