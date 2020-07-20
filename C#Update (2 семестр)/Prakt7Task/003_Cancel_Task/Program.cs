using System;
using System.Threading;
using System.Threading.Tasks;

namespace _003_Cancel_Task
{
    //3. Отмена задания
    class Program
    {
        static CancellationTokenSource ctr = new CancellationTokenSource();
        static CancellationToken token = ctr.Token;

        static void Main(string[] args)
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Click");
                    token.ThrowIfCancellationRequested();
                }
            });

            ctr.Cancel();
            Console.ReadKey();
            task.Start();
            Console.ReadKey();
            Console.WriteLine("Task status: " + task.Status);
            Console.ReadKey();
        }

        /*static void Met(object arg)
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("Met");
                token.ThrowIfCancellationRequested();
            }
        }*/
    }
}
