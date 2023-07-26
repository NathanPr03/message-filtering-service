using Newtonsoft.Json;
using SoftwareEngineering.Message_Processors;

namespace SoftwareEngineering;

public class AllMessagesDto
{
    [JsonProperty] private TextMessageProcessor _textMessageProcessor;
    [JsonProperty] private EmailMessageProcessor _emailMessageProcessor;
    [JsonProperty] private TweetMessageProcessor _tweetMessageProcessor;
    
    public AllMessagesDto(TextMessageProcessor textMessageProcessor, EmailMessageProcessor emailMessageProcessor, TweetMessageProcessor tweetMessageProcessor)
    {
        _emailMessageProcessor = emailMessageProcessor;
        _textMessageProcessor = textMessageProcessor;
        _tweetMessageProcessor = tweetMessageProcessor;
    }
}