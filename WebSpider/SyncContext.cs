using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SyncContext
{
    public static Queue ThreadQ = Queue.Synchronized(new Queue());
    public static Queue StockQ = Queue.Synchronized(new Queue());
}

