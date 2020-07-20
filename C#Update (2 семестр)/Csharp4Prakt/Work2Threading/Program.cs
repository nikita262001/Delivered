using System;
using System.Threading;

namespace Work3Threading
{
    class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            /*
            Timer timer = new Timer(TestWorkMutex, "info", 0, 250);
            //timer.Change(1000, 100);//перезаписывание timer и запуск
            Console.ReadKey();
            timer.Dispose();//останавливает
            */

            WaitOrTimerCallback deleg = TestCallBack;

            ThreadPool.RegisterWaitForSingleObject(auto, deleg, "Test", 1000, false);
            while (true)
            {
                Console.ReadKey();
                auto.Set();
            }
        }
        private static void TestWorkMutex(object obj)
        {
            Console.WriteLine(obj);
        }
        public static void TestCallBack(object state, bool timedOut /*timeout был запущен или сигналом*/)
        {
            Console.WriteLine(timedOut);
        }
    }
}
