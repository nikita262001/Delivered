using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class Cabriolet : Car
    {
        public Cabriolet(double temperature, int vEngine, int hasSafe, int transmission, string name, int maxSpeed, int speed) :
            base(temperature, vEngine, hasSafe, transmission, name, maxSpeed, speed)
        {
        }

        public void OpenRoof(double temperature)
        {
            if (temperature > 35)
            {
                Console.WriteLine("Крыша открыта");
            }
            else
            {
                Console.WriteLine("Крыша не открыта");
            }
        }

        public override int Drive(int km)
        {
            OpenRoof(temperature);

            Console.WriteLine($"Начальная скорость {speed}");

            for (int i = 0; i < km; i++)
            {
                if (temperature < -10)
                {
                    Console.WriteLine("Машина не едит");
                    return 0;
                }
                speed += 5;
            }
            Console.WriteLine($"Скорость {speed}");
            return km;
        }
        public override double CurnSpeed(double speed)
        {
            return speed;
        }
        public override void Info()
        {
            Console.WriteLine($"Температура: {temperature}" +
                $"\nОбъем двигателя: {vEngine}" +
                $"\nКол-во подушек: {hasSafe}" +
                $"\nКол-во передач: {transmission}" +
                $"\nНазвание: {Name}\n");
        }
    }
}
