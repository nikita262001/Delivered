using System;
using System.Collections.Generic;
using System.Threading;

namespace UnitTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(Contains("qw", "qwerty"));
            Console.WriteLine(Contains("ty", "qwerty"));

            Console.WriteLine(Contains("ty", "qwerty"));*/
            string a = "";
            Console.WriteLine((a).GetHashCode());
            Console.WriteLine(("").GetHashCode());
            a = "1";
            Console.WriteLine(("1").GetHashCode());
            Console.WriteLine((a).GetHashCode());
        }
        /*private static bool Contains(string expected, string actual)
        {
            bool chek = false;
            for (int i = 0; i < actual.Length + 1 - expected.Length; i++)
            {
                var a = actual.Substring(i, expected.Length);
                if (expected == actual.Substring(i, expected.Length))
                {
                    chek = true;
                    break;
                }
            }
            return chek;
        }*/
    } 
}
