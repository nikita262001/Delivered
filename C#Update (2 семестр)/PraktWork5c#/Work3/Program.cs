using System;
using System.Threading;

namespace Work3
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(Met);
            AsyncCallback asyncCallback = new AsyncCallback(BeginInvokeMet);

            action.BeginInvoke(asyncCallback, "Конец");

            Console.ReadKey();
        }
        static void Met()
        {
            Console.WriteLine("MetStart");
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("Loading " + i + "%");
            }
        }
        static void BeginInvokeMet(IAsyncResult a)
        {
            Console.WriteLine(a.AsyncState);
            Console.WriteLine("BeginInvokeMet");
        }
    }
}
