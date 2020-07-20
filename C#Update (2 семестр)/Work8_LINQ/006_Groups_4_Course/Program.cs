using System;
using System.Linq;
using Work8_LINQ;

namespace _006_Groups_4_Course
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            var peopleG = from persG in dataBase.Groups
                          where persG.Course == 4
                          select persG;

            //var peopleG = dataBase.Groups.Where((e)=> e.Course == 4);  // 8 Задание

            foreach (var group in peopleG)
            {
                Console.WriteLine(group.NameGroup);

            }
        }
    }
}
