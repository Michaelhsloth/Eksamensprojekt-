using hackerbooking.Server.Services;
using hackerbooking.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hackerbooking.Server.Controllers
{
    [ApiController]

    public class FrivilligeController : ControllerBase
    {
        private readonly FrivilligeService _service;

        public FrivilligeController(FrivilligeService service)
        {
            _service = service;
        }

        [HttpGet("api/Frivillige")]
        public List<FrivilligeDTO> HentFrivillige()
        {
            //Console.WriteLine("api nået");
            return _service.HentFrivillige();

        }

        [HttpGet("api/FindFrivillig{id}")]
        public List<FrivilligeDTO> FindFrivillig(int id)
        {
            //Console.WriteLine("api nået");
            return _service.FindFrivillig(id);

        }

        [HttpPost("api/Frivillig")]
        public async Task<IActionResult> PostFrivillige(FrivilligeDTO frivillig)
        {
            Console.WriteLine("Controlleren");
            await _service.PostFrivillig(frivillig);
            return NoContent();
        }

        [HttpPut("api/updateFrivillig/{id}")]
        public async Task<IActionResult> UpdateFrivillig(int id, FrivilligeDTO frivillig)
        {
            Console.WriteLine("hello");
            await _service.UpdateFrivillig(id, frivillig);
            return NoContent();
        }
    }
}