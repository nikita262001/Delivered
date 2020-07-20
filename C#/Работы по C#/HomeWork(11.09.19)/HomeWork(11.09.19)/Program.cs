using System;

namespace HomeWork_11._09._19_
{
    class Program
    {
        public Timer Clock { get; set; }
        public int Value { get; private set; }
        static void Main(string[] args)
        {
            SuperMarkett Adel = new SuperMarkett("Эдельвейс", 200);
            HomeMarkett Magn = new HomeMarkett("Магнит", 15);
            Console.WriteLine("Введите кол-во дней в Эдельвейсе (от сегодня будет считать)");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во дней в Магните (от сегодня будет считать)");
            int b = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Adel.BuyDay(a);
            Magn.BuyDay(b);
            Adel.Info();
            Magn.Info();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Введите первое число и второе чтобы вычесть");
            int q1 = Int32.Parse(Console.ReadLine());
            int q2 = Int32.Parse(Console.ReadLine());
            Program c1 = new Program { Value = q1 };
            Program c2 = new Program { Value = q2 };
            Program q3 = c1 + c2;
            Console.WriteLine(q3.Value);
            Console.ReadKey();
            Console.Clear();


            Magazinee qwerty1 = new SuperMarkett("Магнит"); // не помню как можно нормально классы переводить
            SuperMarkett qwerty3 = (SuperMarkett)qwerty1;

            Timer time = new Timer(); // как- то так , хотя я сам запутался и думал что будет ошибка (ну хотя я создал еще один класс , можно было в магазин кинуть , но было бы не красиво) DateTime.now(2019,09,12 2:49)
            Program time2 = (Program)time;

        }
        public static Program operator +(Program c1, Program c2)
        {
            return new Program { Value = c1.Value - c2.Value };
        }
    }
    class Timer
    {
        public int Time;
        public int Seconds { get; set; }

        public static explicit operator Program(Timer timer)
        {
            return new Program { Clock = timer };
        }
    }
}
