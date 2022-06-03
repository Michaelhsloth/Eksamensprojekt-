using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OpgaverController : ControllerBase
    {
        private readonly OpgaverService _service;

        public OpgaverController(OpgaverService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<OpgaverDTO> GetOpgaver()
        {
            return _service.GetOpgaver();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpgave(int id)
        {
            await _service.DeleteOpgave(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOpgave(OpgaverDTO opgave)
        {
            await _service.CreateOpgave(opgave);
            return NoContent();
        }
    }
}