using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{

    public class PersonEventArgs
    {
        public string Message { get; private set; }

        public PersonEventArgs(string mes)
        {
            Message = mes;
            Console.WriteLine(Message);
        }
    }
}
