using System;
using System.Collections.Generic;
using System.Threading;

namespace Prakt3
{
    class Program
    {
        static volatile bool i = true; //не надо переберать (jit компиляция) 
        static int j = 0;
        static void Main(string[] args)
        {
            #region FirstWork
            //Thread thread1 = new Thread(TestFirstWhile);
            //thread1.Start();
            //Thread thread2 = new Thread(TestFirst2);
            //thread2.Start();
            #endregion

            #region SecondWork
            //for (int i = 0; i < 100; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(Test);//пул потоки - это потоки которые свободные в самом компьютере
            //}
            //Thread.Sleep(1000);
            //Console.WriteLine("EndFirstThread");
            #endregion

            #region ThirdWork
            List<Person> person = new List<Person>();
            person.Add(new Person(12, "(Пустой)", "(Пустой)", new DateTime(1999, 1, 1)));
            person.Add(new Person(14, "Ник", "Волк", new DateTime(1999, 02, 27)));
            person.Add(new Person(16, "", "", new DateTime(1999, 1, 2)));
            //ThreadPool.QueueUserWorkItem(TestThird, person); надо убрать комментарий чтобы работало ассинхронно
            
            ThreadPool.QueueUserWorkItem(TestThird, person);
            Thread.Sleep(1000);
            #endregion
        }
        static void Test(object state) 
        {
            j++;
            Console.WriteLine(j);
        }
        static void TestFirstWhile()
        {
            while (i)
            {
                Console.WriteLine("Test");
            }
        }
        static void TestFirst2()
        {
            Thread.Sleep(1000);
            i = false;
        }
        static void TestThird(object sender)
        {
            List<Person> person = (List<Person>)sender;
            for (int i = 0; i < person.Count; i++)
            {
                Console.WriteLine(person[i].ToString());
                Thread.Sleep(250);//
            }
        }
    }

    class Person
    {
        int age;
        string firstname;
        string secondname;
        DateTime birthday;

        public Person(int _age, string _firstname ,string _secondname,DateTime _birthday)
        {
            age = _age;
            firstname = _firstname;
            secondname = _secondname;
            birthday = _birthday;
        }

        public int Age { get => age; set => age = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Secondname { get => secondname; set => secondname = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }

        public override string ToString()
        {
            return $"Возраст: {this.Age}, Имя: {this.Firstname}, Фамилия: {this.Secondname}, Дата рождения: {this.Birthday.Day}.{this.Birthday.Month}.{this.Birthday.Year}";
        }
    }
}
