using System;
using System.Threading;

namespace Thread3
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart argum = ParametrSecondThread;
            Thread th1 = new Thread(argum);
            th1.Start("123456789");
        }
        static void ParametrSecondThread(object obj)
        {
            string text = (string)obj;
            foreach (var item in text)
            {
                Console.Write(item);
                Console.Write(".");
                Thread.Sleep(50);
            }
        }
    }
}
