using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LinkController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("get/{code}")]
        public async Task<IActionResult>GetLink(string code)
        {
            string link = _config[code];
            if(link == null)
            {
                return Ok("https://demo.erp.progbiz.io");
            }
            return Ok(link);
        }
    }
}
