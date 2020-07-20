using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate void Test(object sender, PropArgs e);
    class Person
    {
        public event Test Test;
        string name;
        int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                string old = name;
                name = value;
                Test?.Invoke(this,new PropArgs ("Name" , old , name));
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public Person(string name,int age)
        {
            this.age = age;
            this.name = name;
        }
    }
}
