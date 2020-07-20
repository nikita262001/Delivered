using System;
using System.Threading;

namespace PraktWork5
{
    class Program
    {
        static bool _continue = true;
        static void Main(string[] args)
        {

            ThreadPool.QueueUserWorkItem(StartMet);
            Console.ReadKey();
            ThreadPool.QueueUserWorkItem(StartMet);
        }
        static private void StartMet(object e)
        {
            //Thread.CurrentThread.IsBackground = false;
            if (_continue)
            {
                Action action = new Action(MetAction);
                action.BeginInvoke(MetAsunc,"");
                _continue = false;
            }
            else
            {
                Func<int, int> func = new Func<int, int>(MetFunc);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(func(5 * i));
                }
            }
        }
        static private void MetAction()
        {
            Console.WriteLine("MetAction");
        }
        static private int MetFunc(int obj)
        {
            Console.WriteLine("MetFunc");
            return obj;
        }
        static private void MetAsunc(IAsyncResult a)
        {
            Console.WriteLine("MetAsunc");
        }
    }
}