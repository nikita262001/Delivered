using System;
using System.Threading;
using System.Threading.Tasks;

namespace Work5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(Met);
            task.Start();
            Thread.Sleep(100);
        }
        static private void Met()
        {
            Thread.CurrentThread.IsBackground = false;
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            }
        }
    }
}
