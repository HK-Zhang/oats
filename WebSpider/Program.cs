using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebSpider
{
    class Program
    {
        private static ReaderJobManger readerJob = new ReaderJobManger();

        static void Main(string[] args)
        {

            System.Net.ServicePointManager.DefaultConnectionLimit = 50;

            //URLManager.PrepareURLPool();
            ////URLPool.Push("http://nufm3.dfcfw.com/EM_Finance2014NumericApplication/JS.aspx?type=CT&cmd=0022012&sty=FDT&st=z&sr=&p=&ps=&lvl=&cb=&js=var%20jsquote=(x);&token=beb0a0047196124721f56b0f0ff5a27c&rt=0.6847063523412638");
            ////ReaderJobManger readerJob = new ReaderJobManger();
            //readerJob.Run();

            //PaserJobManager parserJob = new PaserJobManager();
            //parserJob.SetupTimeInterval(120000);
            //parserJob.Run();

            //Persistencer StockPersistencer = new Persistencer();
            //StockPersistencer.CleanDB();
            //StockPersistencer.UpdateIntoDB();

            //Console.ReadLine();

            URLManager.PrepareSinaURLPool();
            //URLPool.Push(@"http://vip.stock.finance.sina.com.cn/corp/go.php/vMS_MarketHistory/stockid/600016.phtml?year=2012&jidu=2");
            //URLPool.Push(@"http://vip.stock.finance.sina.com.cn/corp/go.php/vMS_MarketHistory/stockid/600016.phtml?year=2008&jidu=4");
            //URLPool.Push(@"http://vip.stock.finance.sina.com.cn/corp/go.php/vMS_MarketHistory/stockid/600016.phtml?year=2003&jidu=2");
            URLPool.PoolEmptyEvent += URLPool_PoolEmptyEvent;
            readerJob.Run();

            //PaserJobManager<Stock> SHparserJob = new PaserJobManager<Stock>(new SinaHtmlParser());
            //SHparserJob.SetupTimeInterval(3000);
            //SHparserJob.Run();

            //Persistencer StockPersistencer = new Persistencer();
            //StockPersistencer.UpdateIntoDB();

            //PaserJobManager<String> parserJob = new PaserJobManager<String>(new SinaUrlParser());
            //PaserJobManager<StockHistory> parserJob = new PaserJobManager<StockHistory>(new SinaHtmlParser());
            //parserJob.SetupTimeInterval(3000);
            //parserJob.Run();
            Console.ReadLine();
            


        }

        static void URLPool_PoolEmptyEvent(object sender, EventArgs e)
        {
            PaserJobManager<String> parserJob = new PaserJobManager<String>(new SinaUrlParser());
            parserJob.Run();


            readerJob.Run();

            PaserJobManager<Stock> SHparserJob = new PaserJobManager<Stock>(new SinaHtmlParser());
            SHparserJob.SetupTimeInterval(3000);
            Task.Run(new Action(UpdateDB));
            //Task.Run(new Action(UpdateDB));
            SHparserJob.Run();

        }

        static void UpdateDB() {

            Persistencer StockPersistencer = new Persistencer();

            while (true)
            {
                if (!DataPool.IsEmpty() || SyncContext.ThreadQ.Count > 0)
                {
                    Thread.Sleep(1000);
                    StockPersistencer.UpdateIntoDB();

                }
                else {
                    StockPersistencer.UpdateIntoDB();//double check to ensure all object have been processed
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
