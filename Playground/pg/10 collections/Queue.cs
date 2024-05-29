using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._10_collections.queue
{
    class Program
    {
        public static void Start ()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("hello sir!");

            var item = queue.Dequeue();

            Console.WriteLine(item);

        }
    }
}
