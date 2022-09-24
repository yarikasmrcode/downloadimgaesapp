using System;
using System.Net;

class Program
{
    static void Main()
    {
        List<string> ImageList = GetAllImages();
        using (WebClient client = new WebClient())
        {
            for (int i = 1; i < ImageList.Count; i++)
            {
                client.DownloadFile(new Uri(ImageList[i]), @"A:\\" + i + ".jpg"); //куда качать
            }
        }
    }

    public static List<string> GetAllImages()
    {
        List<string> ImageList = new List<string>();
        WebClient x = new WebClient();

        //строка поиска
        string source = x.DownloadString(@"https://www.google.com/search?q=uml+diagrams&client=opera&hs=nbi&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjhpNmA76z6AhVoSPEDHbdrDdoQ_AUoAXoECAMQAw&biw=1536&bih=754&dpr=1.25");

        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

        document.LoadHtml(source);

        foreach (var link in document.DocumentNode.Descendants("img").Select(i => i.Attributes["src"]))
        {
            ImageList.Add(link.Value);
        }
        return ImageList;
    }


}