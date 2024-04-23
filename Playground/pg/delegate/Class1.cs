using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.del.delegat
{
    internal class Program
    {

        public delegate void Delegateee(string str);

        public static void Alarm(string str)
        {
            Console.WriteLine($" help:{str}");
        }

        public static void Alarm2(string str)
        {
            Console.WriteLine($" help:{str}");
        }

        static Delegateee help = Alarm;
        
        public static void Start()
        {
            help += Alarm2;

            help = (string text) =>
            {
                Console.WriteLine($"lAMBDA {text} ");
            };

            help("ddasda");//1

            help?.Invoke("SDAD");//2

            Method((string text) => 
            {
                Console.WriteLine(text);
            });


            Action act = Clousre();
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(500);
                act();
            }

        }


        public static Action Clousre()
        {
            int x = 1;

            Action action = () =>
            {
                x++;
            };

            Action action2 = () =>
            {
                x+=100;
                Console.WriteLine($"action2 {x}");
            };

            Task.Run(() =>
            {
                while (true)
                {
                    Interlocked.Increment(ref x);
                    Console.WriteLine($"while true {x}");
                    Thread.Sleep(200);
                }
            });

            //for (int i = 0; i < 10; i++)
            //{
            //    action();
            //    action2();
            //    Console.WriteLine(x);

            //}

            return action2;

        }

        public static void Method(Delegateee del)
        {
            //del("hELLO");

            del?.Invoke("heeeee");
        }
    }
}
