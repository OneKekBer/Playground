using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._15_TPL.parallel
{


    class Core
    {

    }

    class Program
    {
        public static void Start()
        {
            //Parallel.For(1, 7, i =>
            //{
            //    Console.WriteLine($"curernt i: {i}");
            //    Console.WriteLine($"{i * i}");
            //});

            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            var parallelFor = Parallel.ForEach(list, (item, pls) =>
            {
                Console.WriteLine(pls.ShouldExitCurrentIteration);
                Console.WriteLine($"item: {item}");
            });

            Console.WriteLine(parallelFor.IsCompleted);
        }
    }
}
