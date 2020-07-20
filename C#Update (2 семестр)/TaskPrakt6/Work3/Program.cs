using System;
using System.Threading;
using System.Threading.Tasks;

namespace Work3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(Met1);
            task.Start();

            Thread.Sleep(2000);
            Console.WriteLine("EndCurentThread");
        }
        static private void Met1()
        {
            Thread.CurrentThread.IsBackground = false;
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("Click");
            }
        }
    }
}
