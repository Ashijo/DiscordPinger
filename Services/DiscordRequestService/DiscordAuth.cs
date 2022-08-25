using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Discord;
using Quartz.Util;

namespace DiscordPinger.Services.DiscordRequestService;

public class DiscordAuth
{
    private const string API_ENDPOINT = "https://discord.com/api/v10";
    private const string CLIENT_ID = "978352918241611877";
    private const string CLIENT_SECRET = "wx8G90uhN8Xqxnkrk1i12mVs9JNtKx6o";
    private const string REDIRECT_URI = "https://discord.com/api/oauth2/authorize?client_id=978352918241611877&permissions=68608&scope=bot";
    private const string INSTALL_URL = "https://discord.com/api/oauth2/authorize?client_id=978352918241611877&permissions=68608&scope=bot";
    private const string TEST_URL = "https://discord.com/channels/970016022671278100/970016148634628167";

    private HttpClient _client = new HttpClient();
    
    private string _token;

    public DiscordAuth(){}

    public async Task<string> GetToken()
    {
        if (!_token.IsNullOrWhiteSpace())
        {
            return _token;
        }

        await UpdateToken();
        
        return _token;
    }

    public async Task UpdateToken()
    {
        var contentDict = new Dictionary<string, string>();
//        contentDict.Add("client_id", CLIENT_ID);
//        contentDict.Add("client_secret", CLIENT_SECRET);
//        contentDict.Add("grant_type", "authorization_code");
//        contentDict.Add("code", "/tata/");
//        contentDict.Add("redirect_uri", REDIRECT_URI);
        contentDict.Add("content", "Hello world");
        var content = new FormUrlEncodedContent(contentDict);
        
        _client.DefaultRequestHeaders.Add("type", InteractionResponseType.);
        var result = await _client.PostAsync(TEST_URL, content);
        Console.WriteLine(result);
    }
}