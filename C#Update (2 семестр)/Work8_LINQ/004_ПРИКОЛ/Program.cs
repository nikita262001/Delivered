using System;
using System.Collections.Generic;
using System.Linq;
using Work8_LINQ;

namespace _004_ПРИКОЛ
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            var peopleG = from persG in dataBase.Groups
                          select persG;


            /*foreach (var persG in peopleG)
            {
                var people = from pers in persG.People
                             where pers.Surname[0] == 'П' ||
                                   pers.Surname[0] == 'Р' ||
                                   pers.Surname[0] == 'И' ||
                                   pers.Surname[0] == 'К' ||
                                   pers.Surname[0] == 'О' ||
                                   pers.Surname[0] == 'Л'
                             select pers;
                peopleP.AddRange(people);
            }*/

            var res = (from persG in peopleG
                       from pers in persG.People
                       where pers.Surname[0] == 'П' ||
                                    pers.Surname[0] == 'Р' ||
                                    pers.Surname[0] == 'И' ||
                                    pers.Surname[0] == 'К' ||
                                    pers.Surname[0] == 'О' ||
                                    pers.Surname[0] == 'Л'

                       select new { Character = pers.Surname[0], Person = pers }).OrderByDescending(anon => anon.Character);

            foreach (var item in res)
            {
                Console.WriteLine("Фамилия: " + item.Person.Surname);
            }


            /*var peopleOrder = peopleP.OrderBy((e) => // 8 задание
               { return e.Surname[0] == 'П'; }).OrderBy((e) => // по всему списку пробегает и находит у человека Surname[0] == 'П' и тех кого он нашел кидает вниз списка
               { return e.Surname[0] == 'Р'; }).OrderBy((e) =>
               { return e.Surname[0] == 'И'; }).OrderBy((e) =>
               { return e.Surname[0] == 'К'; }).OrderBy((e) =>
               { return e.Surname[0] == 'О'; }).OrderBy((e) =>
               { return e.Surname[0] == 'Л'; });*/

            /*  foreach (var person in peopleOrder)
              {
                  Console.WriteLine("Фамилия: " + person.Surname);
              }*/
        }
    }
}
