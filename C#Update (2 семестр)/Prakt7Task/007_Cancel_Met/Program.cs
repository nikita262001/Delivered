using System;
using System.Threading;
using System.Threading.Tasks;

namespace _007_Cancel_Met
{
    //7. Отмена работающего callback-метода
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static CancellationToken token = cts.Token;
        static void Main(string[] args)
        {
            Task task = new Task(Met, "Met");
            Task continueWith = task.ContinueWith(MetContinueWith, "MetMetContinueWith");

            task.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.ReadKey();
        }
        static private void Met(object str)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(str);
            }
        }
        static private void MetContinueWith(Task e , object str)
        {
            while (true)
            {
                Thread.Sleep(200);
                Console.WriteLine(str);
                token.ThrowIfCancellationRequested();
            }
        }
    }
}
