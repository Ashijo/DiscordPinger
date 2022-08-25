using System.Text;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DiscordPinger.Services.DiscordRequestService;

public class DiscordRequest
{
    
    private readonly DiscordSocketClient _client;
    private ILogger _logger;
    private TaskCompletionSource<bool> _ready = new TaskCompletionSource<bool>();
    
    // secret : wx8G90uhN8Xqxnkrk1i12mVs9JNtKx6o

    public DiscordRequest(string webhook, ILogger logger)
    {
        _logger = logger;
        //_webhook = webhook;
        _client = new DiscordSocketClient();
        _client.Log += LogDiscord;
        _client.Ready += OnReady;
        _client.LoginAsync(TokenType.Bot, "015f98c31d2196a0178cd918f1a2bb6eff65b95b6178d7e13c054f37f8e45ffa");
        _client.StartAsync();
    }

    
    private Task OnReady()
    {
        _ready.SetResult(true);
        Console.WriteLine("Discord service flagged");
        return Task.CompletedTask;
    }
    
    private Task LogDiscord(LogMessage msg)
    {
        _logger.LogInformation(msg.ToString());
        return Task.CompletedTask;
    }
    
}