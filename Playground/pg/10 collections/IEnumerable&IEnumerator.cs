using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._10_collections.ienum
{
    internal class Program
    {

        public static void Start()
        {
            string[] people = { "tom", "bob", "ilja" };

            IEnumerator peopleEnumerator = people.GetEnumerator();

            while(peopleEnumerator.MoveNext())
            {
                string item = (string)peopleEnumerator.Current;
                Console.WriteLine(item);
            }
           peopleEnumerator.Reset();
        }
    }
}
