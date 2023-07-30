using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SoftwareEngineering.Message_Processors;

public class TweetMessageProcessor : IMessageProcessor
{
    private const string MessageType = "Tweet";
    
    private readonly MessageSplitterService _messageSplitterService = new();
    private readonly TextSpeakReplacer _textSpeakReplacer = new();

    [JsonProperty] private readonly List<string> _mentions = new();
    [JsonProperty] private readonly List<string> _hashtags = new();

    [JsonProperty] private string _header;
    [JsonProperty] private string _sender;
    [JsonProperty] private string _messageText;

    public (string, string) Process(string header, string body)
    {
        _header = header;
        _sender = _messageSplitterService.ExtractSender(body);
        string dirtyMessageText = _messageSplitterService.ExtractMessageText(body);
        Validate(_sender, dirtyMessageText);

        _messageText = _textSpeakReplacer.ReplaceTextSpeak(dirtyMessageText);

        CountMentions(body);
        CountHashtags(body);

        return (MessageType, _messageText);
    }

    public List<string> GetMentions() => _mentions;

    public List<string> GetHashtags() => _hashtags;

    private void CountMentions(string body)
    {
        string pattern = @"@\w+"; // Match '@' followed by one or more word characters

        MatchCollection matches = Regex.Matches(body, pattern);

        int matchCount = 0;
        foreach (Match match in matches)
        {
            if (matchCount == 0)
            {
                matchCount++;
                continue;
            }

            _mentions.Add(match.Value);

            matchCount++;
        }
    }

    private void CountHashtags(string body)
    {
        string pattern = @"#\w+"; // Match '#' followed by one or more word characters

        MatchCollection matches = Regex.Matches(body, pattern);

        foreach (Match match in matches)
        {
            _hashtags.Add(match.Value);
        }
    }

    private void Validate(string sender, string messageText)
    {
        if (sender[0] != '@')
        {
            throw new ArgumentException("The sender must start with an '@'");
        }

        if (sender.Length > 16)
        {
            throw new ArgumentException(
                "The sender length is too long, it can be 16 characters at most (including the '@')");
        }

        if (messageText.Length >= 1028)
        {
            throw new ArgumentException("The message text length is too long, it can be 140 characters at most");
        }
    }
}