using System;
using System.Threading;
using System.Threading.Tasks;

namespace Work4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(Met1);
            Task task2 = new Task(Met2);

            task2.Start();
            task2.Wait(500);

            task1.Start();
            task1.Wait();

            Console.ReadKey();
        }
        static private void Met1()
        {
            Console.WriteLine("StartTask1");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine(i);
            }
            Console.WriteLine("EndTask1");
        }
        static private void Met2()
        {
            Console.WriteLine("StartTask2");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine(i);
            }
            Console.WriteLine("EndTask2");
        }
    }
}
