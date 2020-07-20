using System;
using System.Threading;

namespace TestStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread firstThread = Thread.CurrentThread;
            firstThread.Name = "First";

            ThreadStart threadStart = null;
            threadStart += WorkInSecondThread;

            ParameterizedThreadStart argum = ParametrSecondThread;
            Thread th1 = new Thread(argum);
            th1.Name = "";
            th1.Start("Привет");
            th1.Join();

            Thread th = new Thread(threadStart);
            th.Name = "Second";
            th.Start();


            if (th.ThreadState == ThreadState.Running)
            {
                th.Abort();
            }

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("Работа");
            }
            Console.WriteLine("Поток " + Thread.CurrentThread.GetHashCode() + " завершен");

        }
        static void WorkInSecondThread()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < 120; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(".");
            }

            Console.WriteLine("Поток " + Thread.CurrentThread.Name + " завершен");
        }
        static void ParametrSecondThread(object obj)
        {
            string text = (string)obj;
            foreach (var item in text)
            {
                Console.Write(item);
                Console.Write(".");
                Thread.Sleep(50);
            }
            Console.WriteLine("Поток " + Thread.CurrentThread.GetHashCode() + " завершен");
        }
    }
}
