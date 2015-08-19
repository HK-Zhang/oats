using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSpider
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Net.ServicePointManager.DefaultConnectionLimit = 50;
            URLManager.PrepareURLPool();
            //URLPool.Push("http://nufm3.dfcfw.com/EM_Finance2014NumericApplication/JS.aspx?type=CT&cmd=0022012&sty=FDT&st=z&sr=&p=&ps=&lvl=&cb=&js=var%20jsquote=(x);&token=beb0a0047196124721f56b0f0ff5a27c&rt=0.6847063523412638");
            ReaderJobManger readerJob = new ReaderJobManger();
            readerJob.Run();

            PaserJobManager parserJob = new PaserJobManager();
            parserJob.SetupTimeInterval(120000);
            parserJob.Run();

            Persistencer StockPersistencer = new Persistencer();
            StockPersistencer.CleanDB();
            StockPersistencer.UpdateIntoDB();

            Console.ReadLine();
        }
    }
}
