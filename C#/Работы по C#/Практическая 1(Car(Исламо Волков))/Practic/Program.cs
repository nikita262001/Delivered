using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class Program
    {
        static void Main(string[] args)
        {

            Car sportCar = new SportCar(30,3800,2,6,"Sport",300,200);
            Car badCar = new BadCar(20, 600, 1, 4, "Bad",175,125);
            Car cabriolet = new Cabriolet(40, 1200, 2, 6, "Cabr",150,100);
            
            Console.WriteLine(sportCar.Drive(20) +  " Км проехала");
            sportCar.Info();

            Console.WriteLine(badCar.Drive(10) + " Км проехала");
            badCar.Info();

            Console.WriteLine(cabriolet.Drive(15) + " Км проехала");
            cabriolet.Info();

            double a = 10;
            byte b = 15;
            int c = (int)a + b;

            Console.ReadKey();
        }
    }
}
