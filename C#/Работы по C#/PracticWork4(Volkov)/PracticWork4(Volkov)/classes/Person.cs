using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticWork4_Volkov_
{
    [Serializable]
    public class Person
    {
        private string name;
        private string surname;
        private int age;
        private string work;
        private DateTime date;

        public Person(string name_ , string surname_,int age_, string work_, DateTime date_)
        {
            this.Name = name_;
            this.Surname = surname_;
            this.Age = age_;
            this.Work = work_;
            this.Date = date_;
        }
        public Person()
        { }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string Work { get => work; set => work = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
