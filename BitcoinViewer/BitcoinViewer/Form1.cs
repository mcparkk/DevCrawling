using BitCoinViewer;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BitcoinViewer
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FillCoinList();


        }

    private void FillCoinList()
        {
            var url = "https://www.bithumb.com/trade/order/BTC";
            var coinList = WebController.controller.WebCrawler.GetCoinList(url);

            foreach(var coin in coinList)
            {
                var element = new DevExpress.XtraBars.Navigation.AccordionControlElement();

                element.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
                element.Text = coin;
                element.Click += new EventHandler(Elements_Click);

                CoinElement.Elements.Add(element);
            }
        }

        private void Elements_Click(object sender, EventArgs e)
        {
            var selectedElement = (DevExpress.XtraBars.Navigation.AccordionControlElement)sender;

        }
    }
}
