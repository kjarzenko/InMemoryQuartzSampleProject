using System;
using System.Threading.Tasks;

using InMemoryQuartzSampleWebAPI.Logic;

using Microsoft.Extensions.Logging;

using Quartz;

namespace InMemoryQuartzSampleWebAPI.Jobs
{
    [DisallowConcurrentExecution]
    public class InMemoryJob : IJob
    {
        private readonly ILogger<InMemoryJob> _logger;

        private readonly ISimpleRandomDataGeneratorLogic _simpleRandomDataGeneratorLogic;

        public InMemoryJob(
            ISimpleRandomDataGeneratorLogic simpleRandomDataGeneratorLogic, 
            ILogger<InMemoryJob> logger)
        {
            _simpleRandomDataGeneratorLogic = simpleRandomDataGeneratorLogic;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Job has been started at {DateTime.UtcNow}");
            var message = await _simpleRandomDataGeneratorLogic.GenerateData();
            _logger.LogInformation($"Job has been executed at {DateTime.UtcNow}, produced message: {message}");
        }
    }
}