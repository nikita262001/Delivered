using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static bool _continue = true;
        static void Main(string[] args)
        {

            ThreadPool.QueueUserWorkItem(StartMet);
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
            ThreadPool.QueueUserWorkItem(StartMet);
            Thread.Sleep(10);
            //Console.ReadKey();
        }
        static private void StartMet(object e)
        {
            Console.WriteLine("StartMet");
            Thread.CurrentThread.IsBackground = false;
            if (_continue)
            {
                Action action = new Action(MetAction);
                action.BeginInvoke(MetAsunc, "");
                _continue = false;
            }
            else
            {

                while (true)
                {

                }
                Func<int, int> func = new Func<int, int>(MetFunc);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(func(5 * i));
                }
            }
        }
        static private void MetAction()
        {
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("MetAction");
        }
        static private int MetFunc(int obj)
        {
            Console.WriteLine("MetFunc");
            return obj;
        }
        static private void MetAsunc(IAsyncResult a)
        {
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("MetAsunc");
        }
    }
}
