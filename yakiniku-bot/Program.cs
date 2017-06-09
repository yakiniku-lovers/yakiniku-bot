﻿using System;

namespace yakinikubot
{
    class MainClass
    {
        public static void Main(string[] args)
        {

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
