using System;
using System.Collections.Generic;
using System.Linq;
using Work8_LINQ;

namespace _001_People3Course
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            int count = 0;
            foreach (var groupP in dataBase.Groups) // count
            {
                var people = from pers in groupP.People
                             where groupP.Course == 3
                             select pers;

                count += people.Count();

                foreach (var person in people)
                {
                    Console.WriteLine("Имя: " + person.Name + "\tФамилия: " + person.Surname + "\tГод рождения: " + person.YearOfBirth + "\tКурс: " + groupP.Course);
                }
            }
            Console.WriteLine("На 3 курсе учатся: " + count + " струдентов");
        }
    }
}
