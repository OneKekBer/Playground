using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._15_TPL.intro
{
    internal class Program
    {
        public static void Meth1()
        {
            Console.WriteLine("main start");

            Task task1 = new Task(() => Print(1));
            Task task2 = new Task(() => Print(2));

            task1.RunSynchronously();
            task2.RunSynchronously();

            Console.WriteLine(task1.Id);
            Console.WriteLine(task1.IsCompleted);
            Console.WriteLine(task1.IsCompletedSuccessfully);



            task2.Wait();
            task1.Wait();

            Console.WriteLine("main end");
        }

        public static void Meth2()
        {
            Console.WriteLine("start main");
            
            var outVar = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("outer started");
                Thread.Sleep(5000);
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("inner start");
                    Thread.Sleep(2000);
                    Console.WriteLine("inner end");
                });
                Console.WriteLine("outer end");
            });
            Console.WriteLine("end main");

            //start main
            //end main 
            //outer started
            //outer end 
            //inner start 
            //inner end
        }



        public static void Meth3()
        {
            Console.WriteLine("start main");

            Task task1 = new Task(() => {
                Console.WriteLine("task1 started");
                Thread.Sleep(2000);
                Console.WriteLine("task1 end");
            });

            Task task2 = new Task(() => {
                Console.WriteLine("task2 started");
                Thread.Sleep(1000);
                Console.WriteLine("task2 end");

            });

            
            var outVar = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("outer started");
                Thread.Sleep(5000);
                task1.Start();
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("inner start");
                    Thread.Sleep(2000);
                    Console.WriteLine("inner end");
                    task2.Start();
                    task1.Wait();
                }, TaskCreationOptions.AttachedToParent);
                Console.WriteLine("outer end");
            });
            Console.WriteLine("end main");
            task2.Wait();

            //start main
            //end main
            //outer started 
            //task1 started -- outer end
            //inner start -- task1 started
            //inner end  -- inner start
            //task2 started -- task1 end
            //task1 end -- inner end
            //outer end -- task2 started
            //task2 end 
        }

        public static void Print(int i)
        {
            Console.WriteLine($"task {i} start");
            Thread.Sleep(1000);
            Console.WriteLine($"task {i} end");
        }

        public static void Start()
        {
            //Meth2();
            Meth3();
        }
    }
}
