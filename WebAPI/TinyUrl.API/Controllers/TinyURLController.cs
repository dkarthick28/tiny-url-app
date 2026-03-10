using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TinyUrl.API.Helpers;
using TinyUrl.Service.Interface;

namespace TinyUrl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinyURLController :ControllerBase
    {
        private readonly IService _service;
        private readonly TokenService _tokenService;
        public TinyURLController(IService service , TokenService tokenService)
        {
           this._service= service;
            this._tokenService= tokenService;
        }

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
