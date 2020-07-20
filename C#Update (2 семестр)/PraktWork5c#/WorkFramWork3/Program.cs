using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkFramWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> action = new Func<int>(Met);

            AsyncCallback asyncCallback = new AsyncCallback(BeginInvokeMet);

            IAsyncResult actionBegin = action.BeginInvoke(null,null);

            Console.WriteLine(action.EndInvoke(actionBegin));

            Console.ReadKey();
        }
        static int Met()
        {
            Console.WriteLine("MetStart");
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            return 10;
        }

        static void BeginInvokeMet(IAsyncResult a)
        {
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            AsyncResult result = (AsyncResult)a;
            Console.WriteLine(a.AsyncState);


            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("Loading " + i + "%");
            }
            Console.WriteLine("BeginInvokeMet");
        }
    }
}
