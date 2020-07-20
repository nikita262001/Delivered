
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestsPrakt2
{
    public static class DataWorker
    {
        public static char GetFirstLetterFromName(Person person)
        {
            return person.Name[0];
        }

        public static bool IsPersonAdult(Person person)
        {
            if (person.Age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double GetAverageOfAge(List<Person> list)
        {
            int sum = 1;

            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i].Age;
            }

            return sum / list.Count;
        }

        public static Person GetLastPerson(List<Person> listPerson)
        {
            if (listPerson != null)
            {
                if (listPerson.Count > 0)
                {
                    return listPerson.Last();
                }
                else
                {
                    throw new Exception("List Person empty");
                }
            }
            else
            {
                throw new Exception("List Person not found");
            }
        }
    }
}