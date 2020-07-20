using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Company
    {
        public List<Company> accountscompany = new List<Company>();

        static private int _id_company = 0;
        private string namecompany;
        private string adrescompany;

        public string Namecompany { get => namecompany; set => namecompany = value; }
        public string Adrescompany { get => adrescompany; set => adrescompany = value; }

        public Company(string namecompany, string adrescompany)
        {
            Namecompany = namecompany;
            Adrescompany = adrescompany;
        }
        public Company() { }

        public void NewCompany(string namecompany, string adrescompany)
        {
            if (accountscompany.Count == 0)
            {
                Company defould = new Company("Безработный", "нет места работы");
                accountscompany.Add(defould);
            }
            Company newcompany = new Company(namecompany, adrescompany);
            accountscompany.Add(newcompany);
            _id_company++;
        }
        public void СompanyWithdrawal()
        {
            Console.WriteLine("Существуют на данный момент компании:");
            for (int i = 1; i < accountscompany.Count; i++)
            {
                Console.WriteLine("\nИмя компании: " + accountscompany[i].Adrescompany +
                   "\tАдрес компании: " + accountscompany[i].Namecompany);
            }
        }
    }
}
