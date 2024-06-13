using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.Threading.tplarr
{


    class Core
    {
        Random rnd = new Random();

        public IEnumerable<int> GetRandomArray()
        {
            var list = Enumerable.Range(0, 10000000)
                        .Select(_ => rnd.Next(1, 9000))
                        .ToHashSet();

            return list;

        }

        public int TaskSquareNumber(int num)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return num * 31 * 2 / 2 * 4;
            });

            Console.WriteLine(task.Result);
            return task.Result;
        }

        public IEnumerable<int> SquareArray(IEnumerable<int> list)
        {
            list = list.Select(x => TaskSquareNumber(x))
                .OrderBy(x => x)
                .ToList();

            return list;
        }

    }

    class Program
    {
        

        public static void Start()
        {

            Core core = new Core();
            var arr = core.GetRandomArray();

            Console.WriteLine(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var timer = Stopwatch.StartNew();
            var sqArr = core.SquareArray(arr);

            Console.WriteLine(sqArr);
            foreach (var item in sqArr)
            {
                Console.WriteLine(item);
            }
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }
    }
}
