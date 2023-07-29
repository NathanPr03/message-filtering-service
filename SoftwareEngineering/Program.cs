using SoftwareEngineering;
using SoftwareEngineering.Message_Processors;

void Print(string message)
{
    Console.WriteLine(message);
}

string emailInput = "Sender: 5084985 Subject: SIR 10/11/12 Message Text: 98-76-54 Theft Some message text LMAO https://naerealpal.com";
string tweetInput = "Sender: @NathanAli Message Text: Some message text LMAO this is a tweet @LewisYaWanker #cunt";
// var msgSplitterService = new MessageSplitterService();
// Print("Sender is: " + msgSplitterService.ExtractSender(input));
// Print("Message Text is: " + msgSplitterService.ExtractMessageText(input));
// Print("Subject is: " + msgSplitterService.ExtractSubject(input));

// var text = new TextMessageProcessor();∂
//
// var output = text.Process("esrhue", input);
// Print(output.Item1 + " | " + output.Item2);

// var tweet = new TweetMessageProcessor();
//
// var tweetOutput = tweet.Process("esrhue", tweetInput);
// Print(tweetOutput.Item1 + " | " + tweetOutput.Item2);

// var text = new TextMessageProcessor();
// text.Process("esrhue", emailInput);
//
// var email = new EmailMessageProcessor();
// email.Process("esrhue", emailInput);
//
// var tweet = new TweetMessageProcessor();
// tweet.Process("dujfjdf", tweetInput);
//
// var bigDog = new AllMessagesDto(text, email, tweet);
//
// var json = new JsonWriterService();
// json.WriteToJson(bigDog);

var yml = new YmlToJsonService();
yml.WriteYmlToJson(@"../../../my.yml");