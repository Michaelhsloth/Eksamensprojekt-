using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]

    public class VagtController : ControllerBase
    {
        private vagtService _service;

        public VagtController(vagtService service)
        {
            _service = service;
        }

        [HttpGet("api/Vagt")]
        public List<VagterDTO> getAllVagt()
        {
            //Console.WriteLine("api n�et");
            return _service.getVagter();

        }

        [HttpGet("api/Opgaver")]
        public List<OpgaverDTO> GetAllOpgaver()
        {
            //Console.WriteLine("api n�et");
            return _service.GetOpgaver();

        }

        [HttpGet("Login/Email{Email}Password{Password}")]
        public List<FrivilligeDTO> FrivilligLogin(string Email, string Password)
        {
            Console.WriteLine("api n�et" + Email + Password);
            return _service.Login(Email, Password);

        }

        [HttpDelete("api/Vagt/{id}")]
        public async Task<IActionResult> DeleteVagt(int id)
        {
            Console.WriteLine("api n�et" + id);
            await _service.DeleteVagt(id);
            return NoContent();
        }

        [HttpDelete("api/Opgave/{id}")]
        public async Task<IActionResult> DeleteOpgave(int id)
        {
            Console.WriteLine("api n�et" + id);
            await _service.DeleteOpgave(id);
            return NoContent();
        }
        [HttpPost("api/Vagt")]
        public async Task<IActionResult> postVagt(VagterDTO vagt)
        {
            await _service.postVagt(vagt);
            return NoContent();
        }
        [HttpPost("api/nyOpgave")]
        public async Task<IActionResult> NyOpgave(OpgaverDTO opgave)
        {
            await _service.NyOpgave(opgave);
            return NoContent();
        }
        [HttpPost("api/Frivillig")]
        public async Task<IActionResult> PostFrivillige(FrivilligeDTO frivillig)
        {
            await _service.PostFrivillig(frivillig);
            return NoContent();
        }
        [HttpPut("api/Vagt/{id}")]
        public async Task<IActionResult> putVagt(VagterDTO vagt)
        {
            await _service.putVagt(vagt);
            return NoContent();
        }
    }
}