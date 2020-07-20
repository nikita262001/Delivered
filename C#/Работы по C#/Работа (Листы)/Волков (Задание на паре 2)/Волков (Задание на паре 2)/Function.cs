using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Волков__Задание_на_паре_2_
{
    class Function
    {
        public void CW()
        {
            Console.WriteLine("Задание 1");
        }
        public int Sum(int a, int b, int c, int d)
        {
            Console.WriteLine("Задание 2");
            return a + b + c + d;
        }
        public void Mass1(int[] a)
        {
            Console.WriteLine("Задание 3.1");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        public int[] Mass2(ref int[] a)
        {
            Console.WriteLine("Задание 3.2");
            int b = a.Length;
            for (int i = 0, j = b - 1; i < j; i++, j--)
            {
                int t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
            return  a;
        }

        public int Prov1(int a)
        {
            a++;
            Console.WriteLine(a);
            return a;
        }

        public int[] Prov2(int[] a)
        {
            int[] b = (int[])a.Clone();
            b[0]++;
            return a;
        }

        public double Sumdouble(params double[] list)
        {
            double abc = 0;
            for (int i = 0; i < list.Length; i++)
            {
                abc += list[i];
            }
            return abc;
        }
    }
}
