using System.Collections;
namespace yakinikubot
{
    public class TestGetImages
    {
        public TestGetImages()
        {
            GetImages getImages = new GetImages();

            ArrayList urls = getImages.Get();

            foreach(string url in urls){
                System.Console.WriteLine(url);
            }
        }
    }
}
