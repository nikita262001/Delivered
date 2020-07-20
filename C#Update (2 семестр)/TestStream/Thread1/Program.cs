using System;
using System.Threading;

namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(() =>
            {
                Thread.Sleep(10);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("1");
                    Thread.Sleep(50);
                }
            });
            Thread th2 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("2");
                    Thread.Sleep(50);
                }
            });
            th1.Start();
            th2.Start();
        }
    }
}
