using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Module18
{
    class CommandOne : Command
    {
        Receiver receiver;
        YoutubeClient client;

        public CommandOne(Receiver receiver, YoutubeClient client)
        {
            this.receiver = receiver;
            this.client = client;
        }
        
        public override async void Run()
        {
            try
            {
                receiver.Operation();

                Console.WriteLine("Введите путь для скачивания видео");
                string filePath = Console.ReadLine();

                Console.WriteLine("Введите ссылку на видео");
                string url = Console.ReadLine();

                Console.WriteLine("Получаем информацию о видео...");
                var info = client.Videos.GetAsync(url);

                Console.WriteLine("Скачиваем видео...");
                await client.Videos.DownloadAsync(url, filePath, builder => builder.SetPreset(ConversionPreset.UltraFast));

                Console.WriteLine($"Информация о видео: {info}");

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Ошибка!");
            }
        }
    }
}
    

