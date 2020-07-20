using System;
using System.Collections.Generic;
using System.Linq;
using Work8_LINQ;

namespace _005_StudentVsTeacher
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            var groupsCourse = from pers in dataBase.Groups
                    group pers by pers.Course;

            foreach (var coursP  in groupsCourse)
            {
                var teachers = from teach in dataBase.Teachers
                               where teach.CourseWork == coursP.Key
                               select teach;

                Console.WriteLine("Курс: " + coursP.Key);
                foreach (var group in coursP)
                {
                     Console.WriteLine("\nГруппа: " + group.NameGroup);
                }
                Console.WriteLine();
                foreach (var item in teachers)
                {
                    Console.WriteLine("\tИмя: " + item.Name + "\tФамилия: " + item.Surname);
                }
            }
        }
    }
}
