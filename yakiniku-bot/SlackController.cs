﻿﻿﻿﻿using System;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Web;
using Newtonsoft.Json;
using SlackAPI;

namespace yakinikubot {
	public class SlackController {

		string URL = "";

		public SlackController(bool isChigi) {
			if (isChigi) URL = Config.chigiHouseURL;
			else URL = Config.taoHouseURL;
		}

		public void Upload(string message) {
			var webClient = new WebClient();
			webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=UTF-8");
			webClient.Encoding = Encoding.UTF8;

			var post = new Post(message);
			var json = JsonConvert.SerializeObject(post);

            Console.WriteLine(json);
			webClient.UploadString(URL, json);
		}
	}
}
