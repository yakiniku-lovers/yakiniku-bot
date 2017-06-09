﻿using System;

namespace yakinikubot
{
    class MainClass
    {
        public static void Main(string[] args) {

            Console.WriteLine("Load config file");
            new Config().Load();

            Console.WriteLine("Load image file");
            var image = new ImageList();
            image.Load();
            var path = image.GetRandomFilePath();

            var slack = new SlackController(true);
            slack.Upload(path);
	            
        }
    }
}
