using System;
using System.Collections;


namespace yakinikubot
{
    class MainClass
    {
        public static void Main()
        {
			GetImages getImages = new GetImages();

			ArrayList urls = getImages.Get();

			foreach (string url in urls)
			{
				Console.WriteLine(url);
			}

            getImages.GetUrlsInFile();
        }
    }
}
