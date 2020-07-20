using System;
using System.Linq;
using Work8_LINQ;

namespace _002_Average_Rating_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            foreach (var groupP in dataBase.Groups)
            {
                var people = from pers in groupP.People
                             select new
                             {
                                 Name = pers.Name,
                                 Surname = pers.Surname,
                                 Average = pers.Dictionary.Average((key) => key.Value),
                             };

                foreach (var person in people)
                {
                    if (person.Average >= 4)
                    {
                        Console.WriteLine("Имя: " + person.Name + "\tФамилия: " + person.Surname + "\tКурс: " + groupP.Course);
                    }
                }
            }
        }
    }
}
