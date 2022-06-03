using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VagterController : ControllerBase
    {
        private readonly VagterService _service;

        public VagterController(VagterService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<VagterDTO> GetVagt()
        {
            return _service.GetVagter();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVagt(int id)
        {
            await _service.DeleteVagt(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVagt(VagterDTO vagt)
        {
            await _service.CreateVagt(vagt);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVagt(VagterDTO vagt)
        {
            await _service.UpdateVagt(vagt);
            return NoContent();
        }
        [HttpPut("Tag/{id}")]
        public async Task<IActionResult> TagVagt(int id, FrivilligeDTO frivillig)
        {
            await _service.TagVagt(id, frivillig);
            return NoContent();
        }
    }
}