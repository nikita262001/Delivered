using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_11._09._19_
{
    abstract class Magazinee
    {
        public Magazinee Valuee;
        private string nameMagazine;
        public abstract void Info();
        public int Value { get; set; }
        public double Sum { get; set; }
        public string NameMagazine
        {
            get
            {
                return nameMagazine;
            }
            private set
            {
                Console.WriteLine("Вы создали магазин");
                nameMagazine = value;
            }
        }
        public double Square;

        public Magazinee(string nameMagazine, double square)
        {
            this.NameMagazine = nameMagazine;
            this.Square = square;
        }

        public virtual double BuyDay(double sum)
        {
            return sum;
        }


        public Magazinee(string nameMagazine)
        {
            this.NameMagazine = nameMagazine;
        }

        //public static explicit operator SuperMarkett(Magazinee name)
        //{

        //}
    }
}
