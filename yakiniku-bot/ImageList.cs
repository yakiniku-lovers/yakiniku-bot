using System;
using System.IO;
using System.Collections.Generic;

namespace yakinikubot {

	public class ImageList {

		const string filePath = "/imagelist.txt";

		List<string> imagePath;

		public void Load() {
			imagePath = new List<string>();

        	var path = System.Environment.CurrentDirectory;
        	path += filePath;
        	Console.WriteLine(path);

        	using(var reader = new StreamReader(path)) {
        		while (reader.Peek() > -1) {
        			imagePath.Add(reader.ReadLine());
				}
        	}
        }

        public string GetRandomFilePath() {
        	var rand = new Random();
        	return imagePath[rand.Next(imagePath.Count)];
        }
    }
}
