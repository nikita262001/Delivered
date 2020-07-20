using System;
using System.Threading;

namespace ThreadLectiya
{
    class Program
    {
        volatile static bool k;
        static int x = 0;
        static void Main(string[] args) //Interlocked , CompareExchange(ref a,1,0)
        {
            Thread thread = new Thread(Test);
            thread.Start();

            Thread.Sleep(2000);

            k = true;

            Console.WriteLine();

            //ThreadPool QueueWorkUseItem(WaitCallBack (Foo + параметр)) GetAvailableThreads
        }

        static void Test()
        {
            while (!k)
            {
                x++;
                Console.WriteLine(x);
            }
        }
    }
}
