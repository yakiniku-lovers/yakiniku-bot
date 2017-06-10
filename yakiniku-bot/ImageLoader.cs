using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;


namespace yakinikubot
{
    public class ImageLoader
    {
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

        //        string url = @"https://www.google.co.jp/search?q=%E7%84%BC%E8%82%89&rlz=1C5CHFA_enJP742JP742&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiamqz98LDUAhUITrwKHXCKAdUQ_AUICygC&biw=1050&bih=700#imgrc=_";
        string bingUrl = @"https://www.bing.com/images/search?view=detailV2&ccid=%2fvAZEDOY&id=D61397395EAEDAFFDE1388ADABDC941212FE7732&thid=OIP._vAZEDOY2sIrIt1ZYR9ugwEsDH&q=%E7%84%BC%E8%82%89&simid=608023665316333883&selectedIndex=0&ajaxhist=0";

        string getHtml(string url) {
            string html = "";
            var webClient = new WebClient();
            Stream stream = null;
            StreamReader streamReader = null;
            try
            {
                stream = webClient.OpenRead(url);
                streamReader = new StreamReader(stream, sjisEnc);
                html = streamReader.ReadToEnd();
            }catch(Exception e){
                Console.WriteLine(e);
            }
            finally
            {
                if (streamReader != null) streamReader.Close();
                if (stream != null) stream.Close();
            }
			
            webClient.Dispose();

//			Console.WriteLine(html);


			return html;
        }

        public ArrayList GetImageUrl(){

            //returnするString型になったURLのコレクションを定義
            ArrayList urls = new ArrayList();

            string html = getHtml(bingUrl);

            string[] src = html.Split(' ');

            for (int i = 0; i < src.Length; i++){
//                Console.WriteLine(src[i]);
                if(i + 1 < src.Length && src[i].StartsWith("src=\"http")){
//                    string[] tmp = src[i].Split('&');

//                    string imageurl = tmp[0].Substring(5,tmp[0].Length-6);

//                    urls.Add(imageurl);
                    urls.Add(src[i].Substring(5,src[i].Length-6));
                }
            }

//            Console.WriteLine(bingUrl);

            return urls;
        }

        public void GetUrlsInFile(){
            ArrayList urls = GetImageUrl();

			using (var streamWriter = new StreamWriter("imagelist.txt", false, System.Text.Encoding.GetEncoding("shift_jis"))){
				foreach (string imageurl in urls)
				{
                    streamWriter.WriteLine(imageurl);
				}
			}
        }
    }
}
