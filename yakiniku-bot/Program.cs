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

            Console.WriteLine("Connect twitter");
            var twitter = new TwitterController();
            var slack = new SlackController(true);
            twitter.OnTweetReceived += (obj, e) => {
                if(e.Tweet.Contains("焼肉")) {
                    var text = e.ScreenName + "さんが「" + e.Tweet + "」と呟きました";
                    Console.WriteLine(text);
                    slack.Upload(text);
                    slack.Upload(path);
                }
            };
            twitter.Connect();
        }
    }
}
