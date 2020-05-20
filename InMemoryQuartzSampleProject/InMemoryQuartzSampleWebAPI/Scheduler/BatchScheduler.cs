using InMemoryQuartzSampleWebAPI.Jobs;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

using Quartz;
using Quartz.Impl;

namespace InMemoryQuartzSampleWebAPI.Scheduler
{
    public static class BatchScheduler
    {
        private const string JobTrigger = nameof(JobTrigger);

        public static void UseScheduler(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            var settings = GetConfiguration(configuration);

            if (settings.IsJobEnabled)
            {
                var factory = new StdSchedulerFactory();
                var scheduler = factory.GetScheduler().Result;
                scheduler.JobFactory = new JobFactory(applicationBuilder);
                scheduler.Start();

                var jobDetail = JobBuilder.Create<InMemoryJob>()
                    .StoreDurably()
                    .WithIdentity(nameof(InMemoryJob))
                    .Build();

                var simpleScheduler = SimpleScheduleBuilder.Create();
                var trigger = TriggerBuilder.Create()
                    .WithIdentity(JobTrigger)
                    .WithSchedule(simpleScheduler.RepeatForever().WithIntervalInSeconds(settings.IntervalInSeconds))
                    .Build();

                scheduler.ScheduleJob(jobDetail, trigger);
            }
        }

        private static SchedulerConfiguration GetConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(nameof(SchedulerConfiguration)).Get<SchedulerConfiguration>();
        }
    }
}