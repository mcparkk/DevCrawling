using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace BitCoinViewer
{
    public class CrawlingController
    {
        
        private CrawlingController()
        {
            WebCrawler = new WebCrawler();
        }

        private static CrawlingController _instance;

        public static CrawlingController controller
        {
            get
            {
                if (_instance == null)
                    _instance = new CrawlingController();

                return _instance;
            }
        }
        

        public WebCrawler WebCrawler { get; }




    }
}
