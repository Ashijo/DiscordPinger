using DiscordPinger.Services.DiscordRequestService;
using Quartz;
using Quartz.Impl.Triggers;

namespace DiscordPinger.Jobs;

public class GlobalJob: IJob
{
    public JobConfig? _jobConfig;

    public async Task Execute(IJobExecutionContext context)
    {
        var dataMap = context.MergedJobDataMap;
        _jobConfig = (JobConfig)dataMap["jobConfig"];
        
        Console.WriteLine(ToString());

        var d = new DiscordAuth();
        var t = await d.GetToken();
        Console.WriteLine(t);
        //var client = new DiscordRequest(_jobConfig.Webhook);
        //await client.Ping(_jobConfig.Command);
    }
    
    public override string ToString()
    {
        return $"Hello, I'm a Job names : {_jobConfig.Name} I work for the server {_jobConfig.ServerName}";
    }
}