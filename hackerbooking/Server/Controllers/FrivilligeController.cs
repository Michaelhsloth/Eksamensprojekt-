using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FrivilligeController : ControllerBase
    {
        private readonly FrivilligeService _service;

        public FrivilligeController(FrivilligeService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<FrivilligeDTO> GetFrivillige()
        {
            return _service.GetFrivillige();
        }

        [HttpGet("{id}")]
        public List<FrivilligeDTO> FindFrivillig(int id)
        {
            return _service.FindFrivillig(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFrivillige(FrivilligeDTO frivillig)
        {
            await _service.CreateFrivillig(frivillig);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFrivillig(int id, FrivilligeDTO frivillig)
        {
            await _service.UpdateFrivillig(id, frivillig);
            return NoContent();
        }
    }
}