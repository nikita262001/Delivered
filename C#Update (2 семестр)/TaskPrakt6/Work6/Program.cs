using System;
using System.Threading;
using System.Threading.Tasks;

namespace Work6
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Nick" , SurName = "Volkov"};
            Task task = new Task(Met, person);
            task.Start();
            task.Wait();

        }
        static private void Met(object e)
        {
            Person person = (Person)e;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.SurName +"\n");

            if (person.Name != "Nikita")
            {
                person.Name = "Nikita";
            }

            Console.WriteLine(person.Name);
            Console.WriteLine(person.SurName);

            /*int a = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a);
                Thread.Sleep(100);
                a += i;
            }*/
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
