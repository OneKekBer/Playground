using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.findstringmethod
{
    class Program
    {
        public static void Start()
        {
            string userInput = "fi";
            var db = new List<string>() { "hello", "heksagon","fish","finland", "pendos", "hash", "helium", "pensil", "hellios", "armatura", "arma" };
            var references = FindString(userInput, db);

            foreach (var item in references)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<string> FindString(string input, List<string> db)
        {
            foreach (var item in db)
            {
                if(item.Contains(input))
                    yield return item;
            }
        }
    }
}
