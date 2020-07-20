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
                Console.WriteLine("Возраст:" + person.accounts[i]._age +
                    "Имя:" + person.accounts[i]._name +
                    "Фамилия:" + person.accounts[i]._surname +
                    "Имя компании:" + person.accounts[i]._id_company._namecompany + 
                    "Адрес компании:" + person.accounts[i]._id_company._adrescompany); 

            }
        }
    }
}
