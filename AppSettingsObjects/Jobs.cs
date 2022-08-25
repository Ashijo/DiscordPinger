namespace DiscordPinger.AppSettingsObjects;

public class Jobs
{
    public string Name { get; set; }
    public string CronExpression { get; set;}
    public string Command { get; set;}
    public string ExpectedAnswer { get; set;}
    public string PostErrorWebhook { get; set;}

}