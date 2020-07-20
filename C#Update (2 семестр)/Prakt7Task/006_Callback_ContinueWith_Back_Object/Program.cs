using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_Callback_ContinueWith_Back_Object
{
    //6. Callback вызов с помощью ContinueWith, возвращающий результат
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task<string> task = new Task<string>(Met, null);
            Task<string> continueWith = task.ContinueWith(MetContinue);


            

            task.Start();
            Console.WriteLine(task.Result);
            Console.WriteLine(continueWith.Result);
            
        }
        static private string Met(object e)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("Met");
            }
            return "EndMet";
        }
        static private string MetContinue(Task e)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("MetContinue");
            }
            return "EndMetContinue";
        }
    }
}
