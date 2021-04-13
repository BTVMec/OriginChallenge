using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OriginFinancial.CodingChallenge.Service.Controllers
{
    public class ErrorController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return StatusCode(503, "Service Unavailable");
        }
    }
}
