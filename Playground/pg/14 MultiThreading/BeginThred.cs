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


        public static void Meth2()
        {
            int x = 1;
            Interlocked.Increment(ref x);
            Console.WriteLine(x);
        }

        public static int x = 1;
        private static object locker = new object();

        public static void Meth3()
        {
            
            Thread thread1 = new Thread(Counter);
            Thread thread2 = new Thread(Counter);
            Thread thread3 = new Thread(Counter);


            thread1.Name = "1";
            thread2.Name = "2";
            thread3.Name = "3";



            thread1.Start();
            thread2.Start();
            thread3.Start();

            //thread1.Join();
            //thread2.Join();
            //thread3.Join();

        }

        public static void Counter()
        {
            for (int i = 0; i < 100; i++)
            {
                Interlocked.Increment(ref x);
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");                
            }
        }


        public static void Start()
        {
            Meth3();
            //Thread currThread = Thread.CurrentThread;

            //Console.WriteLine(currThread.IsAlive);

            //Meth1();

            //for (int i = 0; i < 10; i++)
            //{
            //    Thread.Sleep(500);      // задержка выполнения на 500 миллисекунд
            //    Console.WriteLine(i);
            //}
        }
    }
}
