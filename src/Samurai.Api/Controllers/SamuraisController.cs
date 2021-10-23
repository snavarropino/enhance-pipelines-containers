using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samurai.Api.Services;

namespace Samurai.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamuraiService _samuraiService;

        public SamuraisController(ISamuraiService samuraiService)
        {
            _samuraiService = samuraiService;
        }

        [HttpGet]
        public Task<IEnumerable<Models.Samurai>> Get()
        {
            return _samuraiService.GetAllAsync();
        }
    }
}
