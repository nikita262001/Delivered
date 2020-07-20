using System;
using System.Collections.Generic;
using System.Linq;
using Work8_LINQ;

namespace _003_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();


           /* var allAssessments = (new int[0].Select((e) =>      // для того чтобы данные из foreach можно было вывести,
                                  new                           // пустой массив чтобы не было записей
                                  {
                                      Name = String.Empty,     // написал свойства чтобы анонимные классы совпадали
                                      Surname = String.Empty,
                                      SubjectName = String.Empty,
                                      SubjectRaiting = 0,
                                  }).ToList());                 //сделал его Листом ( ToList() ) чтобы можно было добавить через метод AddRange()

            #region можно было и так
            /*var allAssessments = (new[] // можно было и так, но тут бы данные остались
            {
                new
                {
                   Name = String.Empty,
                   Surname = String.Empty,
                   SubjectName = String.Empty,
                   SubjectRaiting = 0,
                 }
            }).ToList();
            #endregion*/


            var items = (from groupP in dataBase.Groups
                         from person in groupP.People
                         from item in person.Dictionary
                         select new
                         {
                             person.Name,
                             person.Surname,
                             SubjectName = item.Key,
                             SubjectRaiting = item.Value,
                         }).GroupBy(e => e.SubjectName);

            //var groupAssessments = allAssessments.GroupBy((e) => e.SubjectName);

            foreach (var groupKey in items)
            {
                Console.WriteLine(groupKey.Key);
                foreach (var item in groupKey)
                {
                    Console.WriteLine("\tИмя: " + item.Name + "\tФамилия: " + item.Surname + "\tПредмет: " + item.SubjectName + "\tОценка: " + item.SubjectRaiting);
                }
            }
        }
    }
}
