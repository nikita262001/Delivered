using System;
using System.Threading;

namespace _002_Cancel_Function
{
    //2. Отмена работы функции во ThreadPool
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static CancellationToken token = cts.Token;

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Met, "WorkMet");
            Console.ReadKey();
            try
            {
                cts.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            };
            //Thread.Sleep(5000);
            Console.WriteLine("End");

            Console.ReadKey();
        }
        static private void Met(object e)
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine(e);
                //token.ThrowIfCancellationRequested();

                try
                {
                    token.ThrowIfCancellationRequested();  // закроется прога если не будет try catch
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception!");
                    //return;
                }
            }
        }
    }

}
