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
        public List<TestDTO> getAllVagt()
        {
            //Console.WriteLine("api nået");
            return _service.getVagter();

        }

        [HttpGet("api/Opgaver")]
        public List<OpgaverDTO> GetAllOpgaver()
        {
            //Console.WriteLine("api nået");
            return _service.GetOpgaver();

        }

        [HttpDelete("api/Vagt/{id}")]
        public async Task<IActionResult> DeleteVagt(int id)
        {
            Console.WriteLine("api nået" + id);
            await _service.DeleteVagt(id);
            return NoContent();
        }

        [HttpDelete("api/Opgave/{id}")]
        public async Task<IActionResult> DeleteOpgave(int id)
        {
            Console.WriteLine("api nået" + id);
            await _service.DeleteOpgave(id);
            return NoContent();
        }
        [HttpPost("api/Vagt")]
        public async Task<IActionResult> postVagt(TestDTO vagt)
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
        public async Task<IActionResult> putVagt(TestDTO vagt)
        {
            await _service.putVagt(vagt);
            return NoContent();
        }
    }
}