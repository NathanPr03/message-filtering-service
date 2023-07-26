using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SoftwareEngineering.Message_Processors;

public class EmailMessageProcessor: IMessageProcessor
{
    private readonly MessageSplitterService _messageSplitterService = new ();
    
    [JsonProperty] private readonly List<string> _quarantineList = new();
    [JsonProperty] private readonly List<SirDto> _sirList = new();
    
    [JsonProperty] private string _sender;
    [JsonProperty] private string _messageText;
    
    public void Process(string header, string body)
    {
        _sender = _messageSplitterService.ExtractSender(body);
        string messageText = _messageSplitterService.ExtractMessageText(body);
        string subject = _messageSplitterService.ExtractSubject(body);
        if (subject.StartsWith("SIR"))
        {
            ProcessSir(messageText, subject);
        }

        _messageText = QuarantineUrls(messageText);
    }

    private void ProcessSir(string message, string subject)
    {
        string date = subject.Substring(4).Trim();
        
        // This likely does not work!
        string sortCode = message[..9].Trim();
        string natureOfIncident = message[9..].Split(' ')[0];

        var sir = new SirDto(date, sortCode, natureOfIncident);
        _sirList.Add(sir);
    }

    private string QuarantineUrls(string message)
    {
        Regex urlRegex = new Regex(@"http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=]*)?");

        return urlRegex.Replace(message, match =>
        {
            _quarantineList.Add(match.Value);
            return "<URL Quarantined>";
        });
    }

}