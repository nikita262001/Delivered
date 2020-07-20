using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Goverment
    {
        public void TableOutput(Person person)
        {
            for (int i = 0; i < person.accounts.Count; i++)
            {
                Console.WriteLine("Возраст: " + person.accounts[i].Age +
                    "\tИмя: " + person.accounts[i].Name +
                    "\tФамилия: " + person.accounts[i].Surname +
                    "\nИмя компании: " + person.accounts[i].companies.Namecompany + 
                    "\tАдрес компании: " + person.accounts[i].companies.Adrescompany);
            }
        }
        public static void RecordPerson(object sender, EventArgs e)
        {
            Person person = (Person)sender;
            Console.WriteLine($"Cменил возраст на {person.Age}" +
                $"Cменил имя на {person.Name}" +
                $"Cменил фамилию на {person.Surname}");
        }
        public static void WorkDelegate()
        {
            Console.WriteLine("Сработал обобщенный делегат");
        }
    }
}
