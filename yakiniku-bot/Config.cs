using System;
using System.IO;

namespace yakinikubot {
    public class Config {
    	
    	const string filePath = "/config";
    	public static string taoHouseURL;
		public static string chigiHouseURL;
        public static string clientId;
        public static string clientSecret;

		public Config() {

		}
		
        public void Load() {
        	var path = System.Environment.CurrentDirectory;
        	path += filePath;
        	Console.WriteLine(path);

        	using(var reader = new StreamReader(path)) {
        		taoHouseURL = reader.ReadLine();
        		chigiHouseURL = reader.ReadLine();
                clientId = reader.ReadLine();
                clientSecret = reader.ReadLine();
        		Console.WriteLine(taoHouseURL);
        		Console.WriteLine(chigiHouseURL);
        	}
        }
    }
}
