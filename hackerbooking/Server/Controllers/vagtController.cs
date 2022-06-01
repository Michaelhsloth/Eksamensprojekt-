using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]

    public class vagterController : ControllerBase
    {
        private vagterService _service;

        public vagterController(vagterService service)
        {
            _service = service;
        }

        [HttpGet("api/Vagter")]
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

        [HttpGet("api/Login/Email{Email}Password{Password}")]
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

        [HttpPut("api/Vagt/{id}")]
        public async Task<IActionResult> putVagt(VagterDTO vagt)
        {
            await _service.putVagt(vagt);
            return NoContent();
        }
        [HttpPut("api/TagVagt/{id}")]
        public async Task<IActionResult> TagVagt(int id, FrivilligeDTO frivillig)
        {
            Console.WriteLine("api n�et" + id + " " + +frivillig.frivillig_id);
            await _service.TagVagt(id, frivillig);
            return NoContent();
        }
    }
}