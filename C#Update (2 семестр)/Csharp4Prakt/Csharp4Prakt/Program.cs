using System;
using System.IO;
using System.Threading;

namespace Csharp4Prakt
{
    class Program
    {
        private static Mutex mutex = new Mutex(false, "Test");
        static int i = 0;
        static void Main(string[] args)
        {
            string path = @"C:\Users\nikit\Desktop\txt.txt";
            Console.ReadKey();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }

            for (int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(TestWorkMutex);
            }

            while (true) { if (i == 20) { break; } }
        }
        private static void TestWorkMutex(object obj)
        {
            mutex.WaitOne();

            string file = File.ReadAllText(@"C:\Users\nikit\Desktop\txt.txt");
            File.WriteAllText(@"C:\Users\nikit\Desktop\txt.txt", file + i + "\n");
            Thread.Sleep(250);
            Console.WriteLine(i);
            i++;

            mutex.ReleaseMutex();
        }
    }
}
