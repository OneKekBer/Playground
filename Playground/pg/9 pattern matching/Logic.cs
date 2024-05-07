using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._9_pattern_matching.logic
{
    internal class Program
    {


        static string CalculateSalary(int salary)
        {
            return salary switch
            {
                <= 3000 => "Оу, а я смотрю ты нищеброд!!",
                <= 5000 => "Нормис",
                <= 9000 => "Вау полгече",
                <= 15000 => "Ты что там вообще делаешь?!",
                _ => "wtf"
            };
        }

        static bool IsAdult(int age)
        {
            return age switch
            {
                >= 18 => true,
                _ => false
            };
        }
        public static void Start()
        {
            Console.WriteLine(IsAdult(13));
            Console.WriteLine(CalculateSalary(222200));
        }
    }
}
