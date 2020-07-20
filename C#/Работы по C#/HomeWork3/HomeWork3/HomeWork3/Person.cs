using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Person
    {
        //public event EventHandler Functions;

        public List<Person> accounts = new List<Person>();

        static private int _id_person = 0;

        public Company _id_company;
        public int _age;
        public string _name;
        public string _surname;

        public Person(int age, string name, string surname, Company id_company)
        {
            _age = age;
            _name = name;
            _surname = surname;
            _id_company = id_company;
        }
        public Person() { }

        public void NewPerson(int age, string name, string surname, Company companies)// добавления аккаунта
        {
            Console.WriteLine("1.Безработный\t2.Работает в компании");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                companies = companies.accountscompany[0];
            }
            else
            {
                companies.СompanyWithdrawal();
                Console.WriteLine("Выбери компанию для нового человека");
                int id_company = Convert.ToInt32(Console.ReadLine());
                companies = companies.accountscompany[id_company];
            }

            _id_company = companies;
            Person newaccount = new Person(age, name, surname, companies);
            accounts.Add(newaccount);
            Console.WriteLine($"\nВы создали человека с id {_id_person}");
            _id_person++;
        }
        public void ChangeWorkplace(Person person)//смена места работы
        {
            person._id_company.СompanyWithdrawal();
            Console.WriteLine("Выбери компанию для нового человека");
            int id_company = Convert.ToInt32(Console.ReadLine());
            person._id_company = person._id_company.accountscompany[id_company];
        }
        public void GetOut(Person person)//увольнение
        {
               person._id_company = person._id_company.accountscompany[0];
        }
    }
}
