using System;
using System.Collections.Generic;
using System.Linq;
using Work8_LINQ;

namespace _007_Bad_People
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            foreach (var groupP in dataBase.Groups)
            {
                var people = groupP.People.Select((pers) => new
                {
                    pers.Name,
                    pers.Surname,
                    groupP.NameGroup,
                    AverageRaiting = pers.Dictionary.Average((key) => key.Value),
                    Status = "Слишком плохие статы",
                }).Where((pers) => pers.AverageRaiting < 3);

                //Console.WriteLine("Группа: " + groupP.NameGroup);
                foreach (var pers in people)
                {
                    Console.WriteLine("\tИмя: " + pers.Name + "\tФамилия: " + pers.Surname + "\tГруппа: " + pers.NameGroup + "\tStatus: " + pers.Status);
                }
                Console.WriteLine();
            }
        }
    }
}
