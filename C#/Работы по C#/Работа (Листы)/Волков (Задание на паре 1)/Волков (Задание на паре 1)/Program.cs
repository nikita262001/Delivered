using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Волков__Задание_на_паре_1_
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 1
            int[] a = { 1, 2, 3, 4, 5, 2019, 3, 4, 12, 5, 2019, 2019 };
            int kol = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 2019)
                {
                    kol++;
                }
            }
            Console.WriteLine(kol);
            */

            /* 2
            char[] a = { 'N', 'i', 'k', 'i', 't', 'a' };
            foreach (char item in a)
            {
                Console.Write(item);
            }
            */

            
            /* 3
            char[] a = { 'a', 't', 'i', 'k', 'i', 'N' };
            int b = a.Length;
            for (int i = 0, j = b - 1; i < j; i++, j--)
            {
                char t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            */

            /* 4
            int a = 0;
            while (true)
            {
                a++;
                if (a == 50)
                {
                    break;
                }
            }
            */

            /*
            int a = 10;
            int b = 10;
            int c = 5;
            int d = 15;
            if (a == b && c > d)
            {
                Console.WriteLine("1)Все нормально");
            }
            else if (a == b || c > d)
            {
                Console.WriteLine("2)Все нормально");
            }
            */
        }
    }
}
