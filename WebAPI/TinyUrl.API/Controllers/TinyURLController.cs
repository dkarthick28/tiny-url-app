using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TinyUrl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinyURLController :ControllerBase
    {
       
        [HttpPost("add")]
        public async Task<IActionResult> AddTinyURL()
        {
            return Ok();
        }

        [HttpDelete("delete/{code}")]
        public async Task<IActionResult> DeleteTinyURLByCode(string code)
        {
            return Ok();
        }

        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllTinyURL([FromQuery]string secretCode)
        {
            return Ok();
        }
        [HttpPut("update/{code}")]
        public async Task<IActionResult> UpdateTinyURLByCode( string code)
        {
            return Ok();
        }

        [HttpGet("get/{code}")]
        public async Task<IActionResult> GetTinyURLByCode(string code)
        {
            return Ok();
        }
        [HttpGet("public")]
        public async Task<IActionResult> GetTinyURLByCode()
        {
            return Ok();
        }
    }
}
