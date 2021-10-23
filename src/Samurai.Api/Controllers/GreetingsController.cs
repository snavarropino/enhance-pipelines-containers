using Microsoft.AspNetCore.Mvc;

namespace Samurai.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok($"Hi! Error seed={Program.ErrorSeed} ({Program.Error}).Error context={Program.ErrorDbContext}.ConnString={Startup.Conn}.");
        }
    }
}