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
          
            try {
            	var config = new Config();
            	config.Load();

	            var slack = new SlackController(false);
	            slack.Upload();
	            
        	} catch(Exception e) {

        	}
        }
    }
}
