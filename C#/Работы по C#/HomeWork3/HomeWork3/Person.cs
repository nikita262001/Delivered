using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public delegate void PersonStateHandler(object sender, PersonEventArgs e);
    class Person
    {
        event PersonStateHandler Lol;
        event EventHandler<PersonEventArgs> Function;
        event EventHandler RecordPerson;

        public List<Person> accounts = new List<Person>();

        public static int id_person = -1;

        public Company companies;
        private int age;
        private string name;
        private string surname;

        public string Name
        {
            get => name;
            private set
            {
                name = value;
                Lol += (sender, e) =>
                {
                    Console.WriteLine("good");
                };
                Function += (sender, e) =>
                {
                    Goverment.WorkDelegate();
                };
                Function(this, new PersonEventArgs("qwe"));
                Lol(this, new PersonEventArgs("Это не проблема"));
            }
        }
        public int Age { get => age; private set => age = value; }
        public string Surname { get => surname; private set => surname = value; }
        public int Id_person { get => id_person; private set => id_person = value; }

        public Person(int age, string name, string surname, Company company)
        {
            Age = age;
            Name = name;
            Surname = surname;
            companies = company;
        }
        public Person() { }

        public void NewPerson(int age, string name, string surname, Company company)// добавления аккаунта
        {
            if (age >= 18)
            {
                Console.WriteLine("1.Безработный\t2.Работает в компании");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    company = company.accountscompany[0];
                }
                else
                {
                    company.СompanyWithdrawal();
                    Console.WriteLine("Выбери компанию для нового человека");
                    int id_company = Convert.ToInt32(Console.ReadLine());
                    company = company.accountscompany[id_company];
                }
            }
            else
            {
                Console.WriteLine("Ваш человек не может работать так как ему нет 18 лет");
                company = company.accountscompany[0];
            }

            companies = company;
            Person newaccount = new Person(age, name, surname, companies);
            accounts.Add(newaccount);
            Id_person++;
            Console.WriteLine($"\nВы создали человека с id {Id_person}");
            /*base.NewPerson(new EventArgs());*/
        }
        public void ChangeWorkplace(Person person)//смена места работы
        {
            person.companies.СompanyWithdrawal();
            Console.WriteLine("Выбери компанию для нового человека");
            int id_company = Convert.ToInt32(Console.ReadLine());
            person.companies = person.companies.accountscompany[id_company];
        }
        public void GetOut(Person person)//увольнение
        {
            person.companies = person.companies.accountscompany[0];
        }
        public void RerecordPerson(int id_person, Person person, Company company)
        {
            Console.WriteLine("Введите свой новый возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите свое новое имя: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите свою новую фамилию: ");
            string surname = Convert.ToString(Console.ReadLine());

            person.accounts[id_person].age = age;
            person.accounts[id_person].name = name;
            person.accounts[id_person].surname = surname;

            RecordPerson += Goverment.RecordPerson;
            RecordPerson(this, new EventArgs());
            RecordPerson -= Goverment.RecordPerson;
        }
    }
}