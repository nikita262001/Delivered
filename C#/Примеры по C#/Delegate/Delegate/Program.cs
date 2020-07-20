using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    //delegate void Deleg(int old, int n);
    class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person("Nick",20);
            a.Name = "Lol1";
            a.Test += N_ProperChange;
            a.Name = "Lol2";

            // Deleg d1 = new Deleg(Slova);//первоначальный метод
            // DrygoiClass a = new DrygoiClass();

            // Action<int, int> test1 = (testt1, testt2) =>
            //{
            //    Console.WriteLine("Action");
            //};

            // Func<int, int, int> test2 = (testt3, testt4) =>
            // {
            //     Console.WriteLine("Func");
            //     return testt3 + testt4;
            //  };

            // Predicate<int> test3 = (testt5) =>
            // {
            //     Console.WriteLine("Predicate");
            //     return testt5 != null;
            // };

            // d1 += a.Deistvie1;//добавление существующего метода

            // test1(10, 15);
            // Console.WriteLine(test2(10, 15));
            // Console.WriteLine(test3(10));

            // d1 += (int y, int u) => //создание нового метода и добавление
            // {
            //     Console.WriteLine("Ymnojenie: " + (y * u));
            // };


            // d1(5, 10);
        }

        static void N_ProperChange(object sender, PropArgs e)
        {
            Console.WriteLine(e.newValue);
            Console.WriteLine(e.oldValue);
            Console.WriteLine(e.propName);
        }

        //static void Slova(int a, int b)
        //{
        //    Console.WriteLine("Slova: " + (a + b));
        //}
        //static void Prikol(int a)
        //{
        //    Console.WriteLine("Vot eto prikol");
        //}
    }
    //class DrygoiClass
    //{
    //    public Deleg Info;
    //    public void Deistvie1(int a, int b)
    //    {
    //        Console.WriteLine("Deistvie(Minus): a - b = " + (a - b));
    //    }
    //    public void Deistvie2(int a)
    //    {
    //        Console.WriteLine("Deistvie2");
    //    }
    //    public void TesterProdolj(int a)
    //    {
    //        Console.WriteLine("TesterProdolj");
    //    }
    //    public virtual void Tester(int a) { }
    //}
}
