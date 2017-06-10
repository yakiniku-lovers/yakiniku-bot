using System;
using System.IO;

namespace yakinikubot {
    public class Config {
    	
    	const string filePath = "/config";
    	public static string taoHouseURL;
		public static string chigiHouseURL;
        public static string consumerKey;
        public static string consumerSecret;
        public static string accessToken;
        public static string accessTokenSecret;

		public Config() {

		}
		
        public void Load() {
        	var path = System.Environment.CurrentDirectory;
        	
            var slack = path + "/slack.config";
        	using(var reader = new StreamReader(slack)) {
        		taoHouseURL = reader.ReadLine();
        		chigiHouseURL = reader.ReadLine();
        		Console.WriteLine(taoHouseURL);
        		Console.WriteLine(chigiHouseURL);
        	}


            var twitter = path + "/twitter.config";
            using(var reader = new StreamReader(twitter)) {
                consumerKey = reader.ReadLine();
                consumerSecret = reader.ReadLine();
                accessToken = reader.ReadLine();
                accessTokenSecret = reader.ReadLine();
            }
        }
    }
}
