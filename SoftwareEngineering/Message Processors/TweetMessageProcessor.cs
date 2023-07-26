using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SoftwareEngineering.Message_Processors;

public class TweetMessageProcessor: IMessageProcessor
{
    private readonly MessageSplitterService _messageSplitterService = new ();
    private readonly TextSpeakReplacer _textSpeakReplacer = new();
    
    [JsonProperty] private readonly List<string> _mentions = new();
    [JsonProperty] private readonly List<string> _hashtags = new();
    
    [JsonProperty] private string _sender;
    [JsonProperty] private string _messageText;
    
    public void Process(string header, string body)
    {
        _sender = _messageSplitterService.ExtractSender(body);
        string dirtyMessageText = _messageSplitterService.ExtractMessageText(body);
        _messageText = _textSpeakReplacer.ReplaceTextSpeak(dirtyMessageText);
        
        CountMentions(body);
        CountHashtags(body);
    }

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
}