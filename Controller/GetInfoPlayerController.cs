using ClashRoyaleApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class GetInfoPlayerController : ControllerBase
    {
        private readonly IClashApiInterfaces _clashApiInterfaces;
        public GetInfoPlayerController(IClashApiInterfaces clashApiInterfaces)
        {
            _clashApiInterfaces = clashApiInterfaces;
        }
        [HttpGet("to-analyze-deck")]
        public async Task<ActionResult> GetInfoPlayerToAnalyzeDeck([FromQuery] string tag)
        {
            try
            {
                var result = await _clashApiInterfaces.GetInfoUser(tag);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}