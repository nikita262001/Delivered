using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _008_Chain_ContinueWith
{
    //8. Цепочка callback-методов
    class Program
    {
        static List<Task> list = new List<Task>();
        static void Main(string[] args)
        {
            Task task = new Task(Met, null); // task => ...

            for (int i = 0; i < 2; i++) 
            {
                if (list.Count == 0)
                    list.Add(task.ContinueWith(MetContinue)); // ... 0 => ...
                else
                    list.Add(list[i-1].ContinueWith(MetContinue)); // ... 1 => 2 => ...
            }

            task.Start();

            Task.WaitAll(list.ToArray());

            //list[list.Count - 1].Wait();
            Console.WriteLine("End");
        }
        static private void Met(object e)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("Met" + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("EndMet");
        }
        static private void MetContinue(Task e)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("MetContinue" + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("EndMetContinue");
        }
    }
}
