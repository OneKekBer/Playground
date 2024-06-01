using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._17_LINQ.linq
{
    internal class Program
    {
        public static void Start()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 3, 6, 8, 2, 21 };

            var list = from p in arr
                       where p > 6
                       orderby p
                       ascending
                       select p;

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
