using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Work2
{
    class Program
    {
        static List<Task> list = new List<Task>();
        static void Main(string[] args)
        {
            list.Add(new Task(Met1));
            list.Add(new Task(Met1));
            list.Add(new Task(Met1));

            Console.WriteLine(list[0].Status + "\n");

            foreach (Task item in list)
            {
                item.Start();
                item.Wait();
            }

            Console.ReadKey();
        }
        static private void Met1()
        {
            foreach (Task item in list)
            {
                Console.WriteLine(item.Id + "" + item.Status);
            }
            Console.WriteLine();
        }

        /*
        Created = 0,
        WaitingForActivation = 1,
        WaitingToRun = 2,
        Running = 3,
        WaitingForChildrenToComplete = 4,
        RanToCompletion = 5,
        Canceled = 6,
        Faulted = 7*/
    }
}
