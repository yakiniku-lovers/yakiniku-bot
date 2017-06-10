using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;


namespace yakinikubot
{
    public class GetImages
    {
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

        //        string url = @"https://www.google.co.jp/search?q=%E7%84%BC%E8%82%89&rlz=1C5CHFA_enJP742JP742&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiamqz98LDUAhUITrwKHXCKAdUQ_AUICygC&biw=1050&bih=700#imgrc=_";
        string url = @"https://www.bing.com/images/search?view=detailV2&ccid=%2fvAZEDOY&id=D61397395EAEDAFFDE1388ADABDC941212FE7732&thid=OIP._vAZEDOY2sIrIt1ZYR9ugwEsDH&q=%E7%84%BC%E8%82%89&simid=608023665316333883&selectedIndex=0&ajaxhist=0";

        string readPage(string u) {
            string html = "";
            WebClient wc = null;
            Stream st = null;
            StreamReader sr = null;
            try
            {
                wc = new WebClient();
                st = wc.OpenRead(u);
                sr = new StreamReader(st, sjisEnc);
                html = sr.ReadToEnd();
            }
            finally
            {
                if (sr != null) sr.Close();
                if (st != null) st.Close();
                if (wc != null) wc.Dispose();
            }
            Console.WriteLine(html);


			return html;
        }

        public ArrayList Get(){

            //returnするString型になったURLのコレクションを定義
            ArrayList urls = new ArrayList();

            string html = readPage(url);

            string[] src = html.Split(' ');

            for (int i = 0; i < src.Length; i++){
//                Console.WriteLine(src[i]);
                if(i + 1 < src.Length && src[i].StartsWith("src=\"http")){
//                    string[] tmp = src[i].Split('&');

//                    string imageurl = tmp[0].Substring(5,tmp[0].Length-6);

//                    urls.Add(imageurl);
                    urls.Add(src[i]);
                }
            }

            Console.WriteLine(url);

            return urls;


        }

        public void GetUrlsInFile(){
            ArrayList urls = Get();
            StreamWriter sw = new StreamWriter("001.txt", false,System.Text.Encoding.GetEncoding("shift_jis"));

            foreach(String imageurl in urls){
                sw.WriteLine(imageurl);
                
            }
            sw.Close();

        }



    }
}
