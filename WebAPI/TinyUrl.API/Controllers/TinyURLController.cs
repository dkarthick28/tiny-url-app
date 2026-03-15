using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TinyUrl.API.Helpers;
using TinyUrl.Service.Interface;
using TinyUrl.ViewModels;

namespace TinyUrl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinyURLController :ControllerBase
    {
        private readonly ITinyURLService _service;
        private readonly TokenService _tokenService;
        public TinyURLController(ITinyURLService service , TokenService tokenService)
        {
           this._service= service;
            this._tokenService= tokenService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTinyURL([FromBody] TinyURLAddViewModel tinyURLAddViewModel )
        {

            // model validations i need to do -pending
            var result = await _service.AddTinyURL(tinyURLAddViewModel);
            return Ok(result);
        }

        [HttpDelete("delete/{code}")]
        public async Task<IActionResult> DeleteTinyURLByCode(string code)
        {
            var result = await _service.DeleteTinyURLByCode(code);
            return Ok(result);
        }

        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllTinyURL([FromQuery]string secretCode)
        {
            if (secretCode == _tokenService.GetSecretToken())
            {
                var result = await _service.DeleteAllTinyURL();
                return Ok(result);
            }
            else
                return Unauthorized();
        }
      
        [HttpGet("get/{code}")]
        public async Task<IActionResult> GetTinyURLByCode(string code)
        {
            var result = await _service.GetTinyURLByCode(code);
            return Ok(result);
        }
        [HttpGet("public")]
        public async Task<IActionResult> GetAllTinyPubicURL()
        {
            var result = await _service.GetAllTinyPubicURL();
            return Ok(result);
        }
        [HttpPut("update/{code}")]
        public async Task<IActionResult> UpdateTinyURLByCode(string code)
        {
            var result =await _service.UpdateTinyURLByCode(code);
            return Ok(result);
        }
    }
}
