using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewAndCells
{
    class Person
    {
        string name;
        int age;
        string surname;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Surname { get => surname; set => surname = value; }

        public Person(string name, int age, string surname)
        {
            this.name = name;
            this.age = age;
            this.surname = surname;
        }
    }
}
