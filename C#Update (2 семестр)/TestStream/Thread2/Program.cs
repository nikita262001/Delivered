using System;
using System.Threading;

namespace Thread2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = Thread.CurrentThread;
            th1.Name = "First";
            Thread th2 = new Thread(Start2);
            th2.Name = "Second";
            //th2.IsBackground = true;
            th2.Start();
            for (int i = 0; i < 1; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("1");
            }
            Console.WriteLine(Thread.CurrentThread.Name);
        }
        static void Start2()
        {
            Thread th3 = new Thread(Start3);
            th3.Name = "Third";
            //th3.IsBackground = true;
            th3.Start();
            //th3.Join();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("2");
            }
            Console.WriteLine(Thread.CurrentThread.Name);
        }
        static void Start3()
        {
            Thread.Sleep(30);
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("3");
            }
            Console.WriteLine(Thread.CurrentThread.Name);
        }
    }
}
