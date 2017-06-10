using System;
using System.Collections;

namespace yakinikubot
{
    class MainClass
    {
        public static void Main(string[] args) {

            Console.WriteLine("Load config file");
            new Config().Load();

            Console.WriteLine("Get image url from web");
            var imageLoader = new ImageLoader();
            imageLoader.GetUrlsInFile();
          
            Console.WriteLine("Load image file");
            var image = new ImageList();
            image.Load();
            var path = image.GetRandomFilePath();

            var twitter = new TwitterController();
            var slack = new SlackController(true);

            twitter.OnYakinikuReceived += (obj, e) => {
                Console.WriteLine(e.ScreenName + "さんが焼肉と呟きました");
                slack.Upload(e.ScreenName + "さんが焼肉と呟きました");
                slack.Upload(path);
            };
            twitter.Connect();
        }
    }
}
