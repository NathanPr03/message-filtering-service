namespace SoftwareEngineering.Message_Processors;

public interface IMessageProcessor
{ 
    (string, string) Process(string header, string body);
}