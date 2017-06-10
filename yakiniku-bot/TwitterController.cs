﻿using System;
using CoreTweet;
using CoreTweet.Streaming;
//using CoreTweet.Streaming.Reactive;

namespace yakinikubot {
    public class TweetEventArgs : EventArgs {
        public string ScreenName;
        public string Tweet;

        public TweetEventArgs(string screenName, string tweet) {
            this.ScreenName = screenName;
            this.Tweet = tweet;
        }
    }

    public class TwitterController {
    	

        public delegate void TweetEventHandler(object sender, TweetEventArgs e);
        public event TweetEventHandler OnTweetReceived;

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
                    if(OnTweetReceived != null) 
                        OnTweetReceived(this, new TweetEventArgs(status.User.ScreenName, status.Text));
        			
    			} else if(message is EventMessage) {
        			var ev = message as EventMessage;
        			// Console.WriteLine(string.Format("{0}:{1}->{2}", ev.Event, ev.Source.ScreenName, ev.Target.ScreenName));
    			}
			}

        }
    }
}
