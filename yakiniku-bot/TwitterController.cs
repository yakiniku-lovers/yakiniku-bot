﻿using System;
using CoreTweet;
using CoreTweet.Streaming;
//using CoreTweet.Streaming.Reactive;

namespace yakinikubot {
    public class YakinikuEventArgs : EventArgs {
        public string ScreenName;

        public YakinikuEventArgs(string screenName) {
            this.ScreenName = screenName;
        }
    }

    public class TwitterController {
    	

        public delegate void YakinikuEventHandler(object sender, YakinikuEventArgs e);
        public event YakinikuEventHandler OnYakinikuReceived;

        public TwitterController() {

        }

        public void Connect() {
            // Tokenの取得
        	var tokens = CoreTweet.Tokens.Create(Config.consumerKey, Config.consumerSecret, Config.accessToken, Config.accessTokenSecret);

            // Streamに接続
        	var stream = tokens.Streaming.StartStream(CoreTweet.Streaming.StreamingType.User,
                new StreamingParameters(replies => "all"));

        	foreach(var message in stream) {
    			if(message is StatusMessage) {
        			var status = (message as StatusMessage).Status;
        			// Console.WriteLine(string.Format("{0}:{1}", status.User.ScreenName, status.Text));
        			if(status.Text.Contains("焼肉")) {
                        if(OnYakinikuReceived != null) 
                            OnYakinikuReceived(this, new YakinikuEventArgs(status.User.ScreenName));
        			}
    			} else if(message is EventMessage) {
        			var ev = message as EventMessage;
        			// Console.WriteLine(string.Format("{0}:{1}->{2}", ev.Event, ev.Source.ScreenName, ev.Target.ScreenName));
    			}
			}

        }
    }
}
