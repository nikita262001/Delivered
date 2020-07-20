using System;
using System.Threading;

namespace Work4AutoRestEvent
{
    class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            new Thread(Met).Start();

            Console.ReadKey();
            auto.Set();

            Console.ReadKey();
            auto.Set();

            Console.ReadKey();
        }
        static private void Met()
        {
            Thread.CurrentThread.IsBackground = true;
            auto.WaitOne();
            Console.WriteLine("Начать?");
            auto.WaitOne();
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("Pressed");
            }
        }
    }
}
