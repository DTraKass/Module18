using Module18;
using YoutubeExplode;

class Program
{
    static void Main(string[] args)
    {
        YoutubeClient client = new YoutubeClient();

        var sender = new Sender();
        var receiver = new Receiver();
        
        var commandOne = new CommandOne(receiver, client);  

        sender.SetCommand(commandOne);

        sender.Run();
    }
}
