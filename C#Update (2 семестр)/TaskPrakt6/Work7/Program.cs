using System;
using System.Threading;
using System.Threading.Tasks;

namespace Work7
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(Met, "qwerty");
            task.Start();
            Console.WriteLine(task.Result);

        }
        static private int Met(object e)
        {
            Console.WriteLine(e);

            int a = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a);
                Thread.Sleep(100);
                a += i;
            }
            return a;
        }
    }
}
