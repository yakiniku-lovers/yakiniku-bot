using System;
using System.Collections;


namespace yakinikubot
{
    class MainClass
    {
        public static void Main()
        {
            var imageLoader = new ImageLoader();
            imageLoader.GetUrlsInFile();
        }
    }
}
