using System;
using System.Threading;

namespace ProektTest3Sinhron
{
    class Program
    {
        static int x = 0;
        static object b = new object(); //объект блокировки(эстафетная палка)
        static Thread[] thread = new Thread[5];
        static void Main(string[] args)
        {
            Thread first = Thread.CurrentThread;
            for (int i = 0; i < 5; i++)
            {
                thread[i] = new Thread(Intrem1); /*Thread threadParam = new Thread(new ParameterizedThreadStart(Intrem3));*/
                thread[i].Start(); /*threadParam.Start(x);*/
            }
            Thread.Sleep(1000);
            Console.WriteLine("Финальная форма числа = " + x);
        }
        static void Intrem()
        {
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " " + x);
            }
        }
        static void Intrem1()
        {
            lock (b) // поток говорит: "Всем стоять! пока я не сделаю свою работу"
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Поток работает? = " + thread[i].GetHashCode() + "  " + thread[i].ThreadState);//Ждать Сон Присоединиться // запущен // остановлен
                }
                for (int i = 0; i < 10; i++)
                {
                    x++;
                    Console.WriteLine(Thread.CurrentThread.GetHashCode() + " " + x);
                }
            }//передает эстафетную палку
            Console.WriteLine("Поток закочен " + Thread.CurrentThread.GetHashCode());
        }
        static void Intrem2()
        {
            Monitor.Enter(b); // поток говорит: "Всем стоять! пока я не сделаю свою работу"
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " " + x);
            }
            Monitor.Exit(b); // кричит что поток свободен
        }
        static void Intrem3(object a)//x = 0 так как копирует и изменяет значение не в статической переменной , а в новой "x"
        {
            int x = (int)a;
            lock (b)
            {
                for (int i = 0; i < 10; i++)
                {
                    x++;
                    Console.WriteLine(Thread.CurrentThread.GetHashCode() + " " + x);
                }
            }
        }
    }
}
