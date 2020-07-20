using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Волков__Задание_на_паре_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Function a = new Function();

            a.CW();

            Console.WriteLine(a.Sum(5, 10, 15, 20));

            int[] mass1 = { 5, 10, 15, 20 };
            a.Mass1(mass1);


            int[] mass2 = { 5, 10, 15, 20 };
            int[] b = a.Mass2(ref mass2);

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }

            int g = 10;
            a.Prov1(g);
            Console.WriteLine(g);

            int[] h = { 1, 2, 3, 4, 5 };
            a.Prov2(h);
            Console.WriteLine(h[0]);

            double j = 5;
            double k = 10;
            double l = 15;
            Console.WriteLine(a.Sumdouble(j, k, l));
        }
    }
}
