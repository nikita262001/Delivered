using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    abstract class Car
    {
        public abstract void Info();


        public double temperature;
        public int vEngine;
        public double hasSafe;
        public double transmission;
        public string name;
        public double speed;
        public int MaxSpeed
        {
            get
            {
                return MaxSpeed;
            }
            set
            {
                
            }
        }
        public static double curnSpeed;
        public static int sec = 0;

        public Car(double temperature, int vEngine, int hasSafe, int transmission, string name, int maxSpeed, int speed)
        {
            this.temperature = temperature;
            this.vEngine = vEngine;
            this.hasSafe = hasSafe;
            this.transmission = transmission;
            this.name = name;
            this.MaxSpeed = maxSpeed;
            this.speed = speed;
        }

        public virtual int Drive(int km)
        {
            return km;
        }

        //public virtual double MaxSpeed(double maxspeed) //макс скорость
        //{
        //    return maxspeed;
        //}
        public virtual double CurnSpeed(double speed) //Начальная скорость
        {
            return speed;
        }
    }
}
