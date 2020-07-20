using System;
using System.Collections.Generic;

namespace Work8_LINQ
{
    public class Person
    {
        string name;
        string surname;
        int yearOfBirth;
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int YearOfBirth { get => yearOfBirth; set => yearOfBirth = value; }
        public Dictionary<string, int> Dictionary { get => dictionary; set => dictionary = value; }
    }
}
