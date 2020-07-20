using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Company
    {
        public List<Company> accountscompany = new List<Company>(100);

        static private int _id_company = 0;
        public string _namecompany;
        public string _adrescompany;


        public Company(string namecompany, string adrescompany)
        {
            _namecompany = namecompany;
            _adrescompany = adrescompany;
        }
        public Company() { }

        public void NewCompany(string namecompany, string adrescompany)
        {
            if (accountscompany.Count == 0)
            {
                Company newcompany = new Company("Безработный", "нет места работы");
                accountscompany.Add(newcompany);
            }
            else
            {
                Company newcompany = new Company(namecompany, adrescompany);
                accountscompany.Add(newcompany);
                Console.WriteLine($"Вы создали компанию с id {_id_company}");
            }
            _id_company++;
        }
        public void СompanyWithdrawal()
        {
            Console.WriteLine("Существует на данный момент компании:");
            for (int i = 1; i < accountscompany.Count; i++)
            {
                Console.WriteLine("\nИмя компании: " + accountscompany[i]._adrescompany +
                   "\tАдрес компании: " + accountscompany[i]._namecompany);
            }
        }
    }
}
