﻿using Newtonsoft.Json;

﻿public class Post {
    
    [JsonProperty("text")]
	string Text;

    [JsonProperty("username")]
	const string UserName = "yakiniku-bot";

	[JsonProperty("icon_emoji")]
	const string IconEmoji = ":meat_on_bone:";

	public Post(string text) {
		this.Text = text;

	}
}