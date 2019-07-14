using BitCoinViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinViewer
{
        public class WebController
    {
        
        private WebController()
        {
            WebCrawler = new WebCrawler();
        }

        private static WebController _instance;

        public static WebController controller
        {
            get
            {
                if (_instance == null)
                    _instance = new WebController();

                return _instance;
            }
        }
        

        public WebCrawler WebCrawler { get; }




    }
}

