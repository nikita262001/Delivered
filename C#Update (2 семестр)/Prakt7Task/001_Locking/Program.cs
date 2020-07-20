using System;
using System.Threading.Tasks;

namespace _001_Locking
{
    //1. Пример замыкания. Передача данных в задачу с помощью замыкания
    class Program
    {
        static Task task;

        static void Main(string[] args)
        {
            SetUpClosure();

            task.Start();
            task.Wait();
        }

        private static void SetUpClosure()
        {

            int nonLocal = 20;
            var pers = new { Name = "Nik", Surname = "Volk", Age = 19, };
            task = new Task(() =>
            {
                Console.WriteLine($"Name: {pers.Name}, Surname: {pers.Surname}, Age: {pers.Age}");
                Console.WriteLine($"7 + {nonLocal} = {nonLocal + 7}");
            });
            nonLocal = 21;
        }
    }
}
