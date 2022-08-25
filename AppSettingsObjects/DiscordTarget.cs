using System.Security.Cryptography;

namespace DiscordPinger.AppSettingsObjects;

public class DiscordTarget
{
    public string Name { get; set; }
    public string Webhook { get; set; }
    public Jobs[] Jobs { get; set; }
}