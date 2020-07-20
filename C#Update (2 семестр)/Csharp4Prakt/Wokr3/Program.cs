using System;
using System.Timers;

namespace Wokr3
{
    class Program
    {
        static Timer timer = new Timer(1000);
        static void Main(string[] args)
        {

            timer.Elapsed += SetTimer;//массив методов(делегат если углубиться)
            timer.AutoReset = true;//повторение
            timer.Enabled = true;//запускает

            Console.WriteLine("\nSetTimer\n");
            Console.ReadKey();//не дает остановить
            timer.Stop();
            Console.WriteLine("СТОП!!!");

        }
        private static void SetTimer(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime);
        }
    }
}
