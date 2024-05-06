using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._9_pattern_matching.coratge
{
    internal class Program
    {


        public static void Start()
        {
            string GetWelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
            {
                ("english", "morning", _) => "Good morning",
                ("english", "evening", _) => "Good evening",
                ("german", "morning", _) => "Guten Morgen",
                ("german", "evening", _) => "Guten Abend",
                (_, _, "admin") => "Hello, Admin",
                _ => "Здрасьть"
            };

            string message = GetWelcome("english", "evening", "user");
            Console.WriteLine(message);  // Good evening

            message = GetWelcome("french", "morning", "admin");
            Console.WriteLine(message);  // Hello, Admin
        }

    }
}
