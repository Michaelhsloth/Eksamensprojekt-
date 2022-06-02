using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]

    public class OpgaverController : ControllerBase
    {
        private readonly OpgaverService _service;

        public OpgaverController(OpgaverService service)
        {
            _service = service;
        }

        [HttpGet("api/Opgaver")]
        public List<OpgaverDTO> GetOpgaver()
        {
            //Console.WriteLine("api nået");
            return _service.GetOpgaver();

        }

        [HttpDelete("api/Opgave/{id}")]
        public async Task<IActionResult> DeleteOpgave(int id)
        {
            Console.WriteLine("api nået" + id);
            await _service.DeleteOpgave(id);
            return NoContent();
        }

        [HttpPost("api/nyOpgave")]
        public async Task<IActionResult> CreateOpgave(OpgaverDTO opgave)
        {
            await _service.CreateOpgave(opgave);
            return NoContent();
        }
    }
}