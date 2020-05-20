using Microsoft.AspNetCore.Builder;

using Quartz;
using Quartz.Spi;

namespace InMemoryQuartzSampleWebAPI.Scheduler
{
    public class JobFactory : IJobFactory
    {
        private readonly IApplicationBuilder _applicationBuilder;

        public JobFactory(IApplicationBuilder applicationBuilder)
        {
            _applicationBuilder = applicationBuilder;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var job = (IJob)_applicationBuilder.ApplicationServices.GetService(bundle.JobDetail.JobType);
            return job;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}