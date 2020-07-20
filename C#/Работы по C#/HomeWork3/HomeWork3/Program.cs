using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor color = Console.ForegroundColor;
            Person accounts = new Person();
            Company companies = new Company();
            Goverment tableoutput = new Goverment();

            Console.WriteLine("Нужно создать новую компанию , так как без компании человек не может работать");
            NewCompany(companies);

            bool replay = true;
            while (replay)
            {
                Console.WriteLine("1.Добавить новый аккаунт\t 2.Добавить компанию \t3.Смена работы человека " +
                    "\t\n4.Уволить человека \t5.Вывод всех людей \t6.Перезапись аккаунта" +
                    "\t\n7.Выйти из программы");
                int number = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (number)
                    {
                        case 1:
                            NewPerson(accounts, companies);
                            break;
                        case 2:
                            NewCompany(companies);
                            break;
                        case 3:
                            ChangeWorkplace(accounts);
                            break;
                        case 4:
                            GetOut(accounts);
                            break;
                        case 5:
                            TableOutput(accounts, tableoutput);
                            break;
                        case 6:
                            RerecordName(accounts, companies);
                            break;
                        case 7:
                            replay = false;
                            break;
                    }

                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }
        public static void RerecordName(Person newaccounts, Company companies)
        {
            Console.WriteLine("Введите id человка которого бы хотели изменить (можно изменить только age,name,surname)");
            int id_person = Convert.ToInt32(Console.ReadLine());
            newaccounts.accounts[id_person].RerecordPerson(id_person, newaccounts, companies);
        }
        public static void NewPerson(Person newaccounts, Company companies)
        {
            Console.WriteLine("Введите свой возраст:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите свое Имя:");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите свое Фамилию:");
            string surname = Convert.ToString(Console.ReadLine());
            newaccounts.NewPerson(age, name, surname, companies);
        }
        public static void NewCompany(Company newcompanies)
        {
            Console.WriteLine("Введите имя компании:");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите адрес компании:");
            string adresname = Convert.ToString(Console.ReadLine());
            newcompanies.NewCompany(name, adresname);
        }
        public static void ChangeWorkplace(Person accounts)
        {
            accounts.ChangeWorkplace(accounts);
        }
        public static void GetOut(Person accounts)
        {
            accounts.GetOut(accounts);
        }
        public static void TableOutput(Person accounts, Goverment tableoutput)
        {
            tableoutput.TableOutput(accounts);
        }
    }
}
