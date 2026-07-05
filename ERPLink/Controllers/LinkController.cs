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
            
            if (link == null)
            {
                if (code.ToLower().Contains("_test"))
                    return Ok("https://erptest.progbiz.in");
                else if (code.ToLower().Contains("_dev"))
                    return Ok("https://devtest.progbiz.in");
                if (code.ToLower().Contains("_poc"))
                    return Ok("https://poc.progbiz.in");
                else
                    return Ok("https://erp.progbiz.io");
            }
            return Ok(link);
        }
    }
}
