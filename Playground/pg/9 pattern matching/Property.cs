using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._9_pattern_matching.prop
{
    class Person
    {
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public string Language { get; set; } = "";
    }

    internal class Program
    {


        static string GetMessage(Person? p) => p switch
        {

            { Language: "english" } => "Hi!!",
            { Language: "french" } => "bonjur!",
            { Language: var lang } => $"undefinded language {lang}",
            null => "nullity"
        };

        static void SayHello(Person person)
        {
            if (person is Person { Language: "english", Status: "admin" })
            {
                Console.WriteLine("Hello, admin");
            }
            else if (person is Person { Language: "french" })
            {
                Console.WriteLine("Salut");
            }
            else
            {
                Console.WriteLine("Hello");
            }
        }

        public static void Start()
        {
            Person tom = new Person { Language = "english", Status = "user", Name = "Tom" };
            Person pierre = new Person { Language = "french", Status = "user", Name = "Pierre" };
            Person admin = new Person { Language = "english", Status = "admin", Name = "Admin" };

            SayHello(tom);

            Console.WriteLine(GetMessage(tom));
            Console.WriteLine(GetMessage(new Person { Language = "", Status = "", Name = "" })); //default hello
            Console.WriteLine(GetMessage(null)); // nulity
            
            
        }
    }
}
