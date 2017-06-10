using System;
using System.Collections;

namespace yakinikubot
{
    class MainClass
    {
        public static void Main(string[] args) {

            Console.WriteLine("Load config file");
            new Config().Load();
  
  
            var imageLoader = new ImageLoader();
            imageLoader.GetUrlsInFile();
          
            Console.WriteLine("Load image file");
            var image = new ImageList();
            image.Load();
            var path = image.GetRandomFilePath();

            var slack = new SlackController(true);
            slack.Upload(path);
	            
        }
    }
}
