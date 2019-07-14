using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Web;

namespace BitCoinViewer
{
    public class WebCrawler
    {
        public WebCrawler()
        {

        }

        public List<string> GetCoinList(string url)
        {
            List<string> result = new List<string>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            request.UseDefaultCredentials = true;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string htmlString;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                htmlString = reader.ReadToEnd();
            }


            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlString);

            var coinList
                = document.DocumentNode.SelectNodes("//div[@id='aside_coin']").FirstOrDefault().Descendants("a").Where(x => x.Attributes["data-sorting"] != null);


            foreach (var coin in coinList)
            {
                result.Add(coin.InnerText);
            }

            return result;
        }

    }
}
