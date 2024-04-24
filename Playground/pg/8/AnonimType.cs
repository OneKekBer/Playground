using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.anonimus
{
    internal class Program
    {


        public static void Start()
        {
            var human = new { Name = "Iljo", Age = 200 };

            Console.WriteLine(human.GetType()); //<>f__AnonymousType0`2[System.String,System.Int32]

            //human.Age = 21; !! ONLY FOR READ!!

            var people = new[]
            {
                new {Name="Tom"},
                new {Name="Bob"}
            };


            foreach (var p in people)
            {
                Console.WriteLine(p.Name);
            }



        }
    }
}
