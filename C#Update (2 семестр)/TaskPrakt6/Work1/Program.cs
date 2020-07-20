using System;
using System.Threading.Tasks;

namespace Work1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(Met1);

            task1.Start();
            Task task2 = Task.Factory.StartNew(Met2, "");
            Task task3 = Task.Run(() => { Console.WriteLine("start3"); });

            Console.ReadKey();
        }
        static private void Met1()
        {
            Console.WriteLine("start1");
        }
        static private void Met2(object e)
        {
            Console.WriteLine("start2");
        }
    }
}
