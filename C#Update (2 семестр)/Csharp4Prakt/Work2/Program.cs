using System;
using System.IO;
using System.Threading;

namespace Work2
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(3, 3, "Test");
        static void Main(string[] args)
        {
            Console.ReadKey();
            for (int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(TestWorkMutex);
            }

            Thread.Sleep(3000);
        }
        private static void TestWorkMutex(object obj)
        {
            semaphore.WaitOne();
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " начинает обслуживать");
            Thread.Sleep(250);
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " обслуживание закончилось");
            semaphore.Release();
        }
    }
}
