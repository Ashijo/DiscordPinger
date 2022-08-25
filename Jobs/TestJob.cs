using Quartz;

namespace DiscordPinger.Jobs;

public class TestJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("flagged");
        
    }

}