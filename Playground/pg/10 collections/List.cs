using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._10_collections.list
{
    internal class Program
    {
        public static void Start()
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 4, 4, 4, 5, 6, 7, 1, 4, 2, 7, 9, 1, 100 };

            Console.WriteLine(intList.Exists(x => x == 50)); //false

            Console.WriteLine(intList.Find(x => x == 6)); //6

            var newList = intList.FindAll(x => x == 4); // List { 4,4,4,4 }

            foreach (var i in newList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(intList.Contains(4)); //true

            intList.Sort();

            Console.WriteLine();

            foreach (var i in intList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
