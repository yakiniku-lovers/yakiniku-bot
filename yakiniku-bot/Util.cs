﻿﻿using System;
using System.Net;
using System.IO;

namespace yakinikubot {
  
  public class Util {

    string url = "https://www.cman.jp/network/support/go_access.cgi";

    public string GetIPAdress() {
      var request = (HttpWebRequest)WebRequest.Create(url);
      request.Method = "GET";
      var response = (HttpWebResponse)request.GetResponse();

      var streamReader = new StreamReader(response.GetResponseStream());
      string content = streamReader.ReadToEnd();
      
      var index = content.IndexOf("keyHostName");

      while(content[index] != '\'') index += 1;
      index++;

      string ip = "";

      while(content[index] != '\'') {
        ip += content[index];
        index += 1;
      }

      return ip;
    }
  }
}
