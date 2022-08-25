namespace DiscordPinger;

public class DaemonConfig
{
    public string DaemonName { get; set; }
    public bool? DevMode
    {
        get { return DevMode ?? false; }
        set { DevMode = value; }
    } 
}