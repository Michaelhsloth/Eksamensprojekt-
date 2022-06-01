using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]

    public class VagterController : ControllerBase
    {
        private readonly VagterService _service;

        public VagterController(VagterService service)
        {
            _service = service;
        }

        [HttpGet("api/Vagter")]
        public List<VagterDTO> getAllVagt()
        {
            //Console.WriteLine("api nået");
            return _service.getVagter();

        }

        [HttpDelete("api/Vagt/{id}")]
        public async Task<IActionResult> DeleteVagt(int id)
        {
            Console.WriteLine("api nået" + id);
            await _service.DeleteVagt(id);
            return NoContent();
        }

        [HttpPost("api/Vagt")]
        public async Task<IActionResult> postVagt(VagterDTO vagt)
        {
            await _service.postVagt(vagt);
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
            Console.WriteLine("api nået" + id + " " + +frivillig.frivillig_id);
            await _service.TagVagt(id, frivillig);
            return NoContent();
        }
    }
}