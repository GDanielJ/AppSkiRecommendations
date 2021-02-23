using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StartupController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API is running";
        }
    }
}
