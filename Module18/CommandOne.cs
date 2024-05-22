﻿using YoutubeExplode;
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
                Console.WriteLine("Введите путь для скачивания видео");
                string filePath = Console.ReadLine();

                Console.WriteLine("Введите ссылку на видео");
                string url = Console.ReadLine();

                var info = client.Videos.GetAsync(url);

                await client.Videos.DownloadAsync(url, filePath, builder => builder.SetPreset(ConversionPreset.UltraFast));

                Console.WriteLine($"Информация о видео: {info}");

                receiver.Operation();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
    

