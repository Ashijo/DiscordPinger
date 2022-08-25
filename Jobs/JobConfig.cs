using Quartz;
using Quartz.Impl.Triggers;

namespace DiscordPinger.Jobs;

public class JobConfig
{
    public JobConfig(string name, string cronExpression, string webhook, string serverName, string command, string expectedAnswer, string postErrorWebhook)
    {
        Name = name;
        CronExpression = cronExpression;
        Webhook = webhook;
        ServerName = serverName;
        Command = command;
        ExpectedAnswer = expectedAnswer;
        PostErrorWebhook = postErrorWebhook;
    }

    public string Name { get; }
    public string CronExpression { get; }
    public string Webhook { get; }
    public string ServerName { get; }
    public string Command { get; }
    public string ExpectedAnswer { get; }
    public string PostErrorWebhook { get; }

    

}