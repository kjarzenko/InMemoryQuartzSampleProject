namespace InMemoryQuartzSampleWebAPI
{
    public class SchedulerConfiguration
    {
        public int IntervalInSeconds{ get; set; }

        public bool IsJobEnabled { get; set; }
    }
}