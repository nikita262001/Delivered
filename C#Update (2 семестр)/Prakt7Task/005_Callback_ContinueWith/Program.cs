using System;
using System.Threading;
using System.Threading.Tasks;

namespace _005_Callback_ContinueWith
{
    //5. Callback вызов с помощью ContinueWith
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(Met , null);
            Task continueWith = task.ContinueWith(MetContinue);

            task.Start();
            Console.ReadKey();
        }
        static private void Met(object e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("Met");
            }
        }
        static private void MetContinue(Task e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("MetContinue");
            }
        }
    }
}
