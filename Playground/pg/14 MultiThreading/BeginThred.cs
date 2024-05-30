using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Playground.pg.MultiThreading.beginThred
{
    internal class Program
    {
        public static void Thread1()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Первый поток {i}");
            }
        }

        public static void Thread2()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine($"Второй поток {i*i}");
            }
        }

        public static void Meth1()
        {
            Thread thread = new Thread(Thread1);
            Thread thread1 = new Thread(Thread2);

            thread.Start();
            thread1.Start();
        }


        public static void Start()
        {
            Thread currThread = Thread.CurrentThread;

            Console.WriteLine(currThread.IsAlive);

            Meth1();

            //for (int i = 0; i < 10; i++)
            //{
            //    Thread.Sleep(500);      // задержка выполнения на 500 миллисекунд
            //    Console.WriteLine(i);
            //}
        }
    }
}
