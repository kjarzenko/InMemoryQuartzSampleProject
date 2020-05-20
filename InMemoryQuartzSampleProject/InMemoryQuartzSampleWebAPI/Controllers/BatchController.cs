using System.Threading.Tasks;
using InMemoryQuartzSampleWebAPI.Logic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InMemoryQuartzSampleWebAPI.Controllers
{
    [Route("batch")]
    public class BatchController : Controller
    {
        private readonly ISimpleRandomDataGeneratorLogic _simpleRandomDataGeneratorLogic;

        public BatchController(ISimpleRandomDataGeneratorLogic simpleRandomDataGeneratorLogic)
        {
            _simpleRandomDataGeneratorLogic = simpleRandomDataGeneratorLogic;
        }

        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> Run()
        {
            var message = await _simpleRandomDataGeneratorLogic.GenerateData();

            return Ok(message);
        }
    }
}