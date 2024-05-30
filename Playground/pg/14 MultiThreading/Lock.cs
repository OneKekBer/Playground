using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._14_MultiThreading.locks
{
    internal class Program
    {
        static object locker = new ();

        public static void Method1()
        {
            for (int i = 0; i < 5; i++)
            {
                //Thread thread = new Thread(() => );
                //thread.Name = i.ToString();
                //thread.Start();
                Print(i);
            }
        }


        public static void Print(int count)
        {
            lock (locker) // lock позваляет пройти одному потоку и потом дает другому 
                          // но тогда в чем смысл если можно просто не использовать потоки??
                          // я проверил все тоже самое
            {
                int x = 1;
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"поток {count} значение: {x++}");
                }
            }
        }

        public static void Start()
        {
            Method1();
        }
    }
}
