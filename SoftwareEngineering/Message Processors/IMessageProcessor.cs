namespace SoftwareEngineering.Message_Processors;

public interface IMessageProcessor
{ 
    void Process(string header, string body);
}