using System;
using System.Threading;
using System.Threading.Tasks;

namespace _004_Cancel_Task_Back_Object
{
    //4. Отмена задания, возвращающего значение - обработка исключения
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static CancellationToken token = cts.Token;

        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(Met,"");
            task.Start();

            try
            {
                Console.ReadKey();
                cts.Cancel();
                Console.WriteLine(task.Result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception!!!\n" + e.Message);
            }
            Console.ReadKey();
        }
        static int Met(object arg)
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("Met");
                token.ThrowIfCancellationRequested();
            }
            return 0;
        }
    }
}
