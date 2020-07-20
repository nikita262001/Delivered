using System;
using System.Collections.Generic;
using System.Text;

namespace Work8_LINQ
{
    public class Group
    {
        string nameGroup;
        int course;
        List<Person> people = new List<Person>();

        public string NameGroup { get => nameGroup; set => nameGroup = value; }
        public int Course { get => course; set => course = value; }
        public List<Person> People { get => people; set => people = value; }
    }
}
