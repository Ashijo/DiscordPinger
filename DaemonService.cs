using DiscordPinger.AppSettingsObjects;
using DiscordPinger.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace DiscordPinger;

public class DaemonService: IHostedService, IDisposable
{
    private readonly ILogger _logger;
    private readonly IOptions<DaemonConfig> _config;
    private readonly List<JobConfig> _jobs;

    public DaemonService(ILogger<DaemonService> logger, IOptions<DaemonConfig> config)
    {
        _logger = logger;
        _config = config;
        var appsettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        
        var targets = appsettings.GetRequiredSection("DiscordTargets").Get<DiscordTarget[]>();

        _jobs = new List<JobConfig>();
        foreach (var target in targets)
        {
            _jobs.AddRange(target.Jobs.Select(appSettingsJobs =>
                new JobConfig(appSettingsJobs.Name,
                    appSettingsJobs.CronExpression,
                    target.Webhook,
                    target.Name,
                    appSettingsJobs.Command,
                    appSettingsJobs.ExpectedAnswer,
                    appSettingsJobs.PostErrorWebhook))
            );
        }

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new StdSchedulerFactory();
        var scheduler = await factory.GetScheduler();
        await scheduler.Start();
        
        foreach (var job in _jobs)
        {
            var jobDetail = JobBuilder.Create<GlobalJob>()
                .WithIdentity($"{job.Name}_job", job.ServerName)
                .Build();

            jobDetail.JobDataMap.Put("jobConfig", job);
            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{job.Name}_trigger", job.ServerName)
                .WithCronSchedule(job.CronExpression)
                .Build();
            
             await scheduler.ScheduleJob(jobDetail, trigger);
        }
        
     
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
    }
}