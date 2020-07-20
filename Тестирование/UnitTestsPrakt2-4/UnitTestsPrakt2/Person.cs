using System;


namespace UnitTestsPrakt2
{
    public class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {

        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public object Clone()
        {
            return new Person()
            {
                Name = this.Name,
                Age = this.Age
            };
        }

        public Person ClonePerson()
        {
            return new Person()
            {
                Name = this.Name,
                Age = this.Age
            };
        }
    }
}