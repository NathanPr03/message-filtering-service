using Newtonsoft.Json;
using SoftwareEngineering.Message_Processors;

namespace SoftwareEngineering;

public class AllMessagesDto
{
    [JsonProperty] private EmailMessageProcessor _emailMessageProcessor;

    [JsonProperty] private TextMessageProcessor _textMessageProcessor;

    [JsonProperty] private TweetMessageProcessor _tweetMessageProcessor;


    public AllMessagesDto(EmailMessageProcessor emailMessageProcessor, TextMessageProcessor textMessageProcessor, TweetMessageProcessor tweetMessageProcessor)
    {
        _emailMessageProcessor = emailMessageProcessor;
        _textMessageProcessor = textMessageProcessor;
        _tweetMessageProcessor = tweetMessageProcessor;
    }
}