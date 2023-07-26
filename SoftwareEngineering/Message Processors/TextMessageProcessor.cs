using Newtonsoft.Json;

namespace SoftwareEngineering.Message_Processors;

public class TextMessageProcessor: IMessageProcessor
{
    private readonly MessageSplitterService _messageSplitterService = new ();
    private readonly TextSpeakReplacer _textSpeakReplacer = new();
    
    [JsonProperty] private string _sender;
    [JsonProperty] private string _messageText;
    
    public void Process(string header, string body)
    {
        _sender = _messageSplitterService.ExtractSender(body);
        
        string dirtyMessageText = _messageSplitterService.ExtractMessageText(body);
        _messageText = _textSpeakReplacer.ReplaceTextSpeak(dirtyMessageText);
    }
}