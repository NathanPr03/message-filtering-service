using Newtonsoft.Json;

namespace SoftwareEngineering;

public class JsonWriterService
{
    public void WriteToJson(Object objectToWrite)
    {
        string jsonString = JsonConvert.SerializeObject(objectToWrite);
        Console.WriteLine(jsonString);
        
        string filePath = @"../../../serialised.json";
        
        File.WriteAllText(filePath, jsonString);
    }
}