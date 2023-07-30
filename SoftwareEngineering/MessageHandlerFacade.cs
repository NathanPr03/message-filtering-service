using SoftwareEngineering.Message_Processors;

namespace SoftwareEngineering;

public class MessageHandlerFacade
{
    private readonly RouterService _routerService = new();
    private readonly JsonWriterService _jsonWriterService = new();
    
    private readonly List<(string, string)> _messages = new();

    public void AddMessage(string header, string body)
    {
        IMessageProcessor messageProcessor = _routerService.Route(header);
        (string, string) messageInfo = messageProcessor.Process(header, body);
        
        _messages.Add(messageInfo);
    }

    public void WriteToJsonOnSessionFinish()
    {
        _jsonWriterService.WriteToJson(_messages);
    }
}