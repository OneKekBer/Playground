using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._16_Async.intro
{
    internal class Program
    {


        public async static Task Method1()
        {
            await Task.Delay(1000);

            Console.WriteLine("End");
        }

        public async static Task<int> Method2()
        {
            Task.Delay(100);
            return 2 + 2;
        }

        public async static Task<int> Method3()
        {
            var task = await Task.Run(() =>
            {
                return 2 + 2;
            });

            return task;
        }

        public async static ValueTask<int> Method4()
        {
            await Task.Delay(10);
            return 2 + 22;
        }

        public static void Start()
        {
            //var task = Method1();

            //Console.WriteLine(task);

            //var task2 = Method2();
            //Console.WriteLine(task2.Result);


            var task4 = Method4();
            Console.WriteLine(task4);
            var response = task4.AsTask();
            Console.WriteLine(response + " response ");


        }
    }
}
