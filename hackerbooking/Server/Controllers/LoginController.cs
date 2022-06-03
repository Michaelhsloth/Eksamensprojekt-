using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpGet("Email{Email}Password{Password}")]
        public List<FrivilligeDTO> FrivilligLogin(string email, string password)
        {
            return _service.FrivilligLogin(email, password);
        }
    }
}