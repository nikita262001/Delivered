using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_11._09._19_
{
    class SuperMarkett : Magazinee
    {
        private DateTime date = DateTime.Today;
        private double days = 0;
        Random random = new Random();
        public SuperMarkett(string nameMagazine, double square )
            : base(nameMagazine, square)
        {
            this.Square = square;
        }
        public override void Info()
        {
            Console.WriteLine($"Название магазина: {NameMagazine}" +
                $"\nПлощадь {Square}" +
                $"\nСегодня дата {date.AddDays(days).Date}" +
                $"\nВыручка составляет {Sum}\n");
        }

        public override double BuyDay(double Day)
        {
            days = Day;
            int i;
            Sum = 0;
            for (i = 0; date.AddDays(i) < date.AddDays(Day); i++)
            {
                double a = random.Next(50, 52);
                Sum += a;
            }
            return Sum;
        }

        public SuperMarkett(string nameMagazine):base(nameMagazine)
        {

        }
    }
}
