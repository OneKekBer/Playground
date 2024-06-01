using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Playground.projects.Threading.factorial
{
    internal class Program
    {
        object locker = new object();
        public static decimal FindFactorial(int x, decimal sum = 1)
        {
            if (x == 1) return sum;
            sum *= x;
            return FindFactorial(x - 1, sum);
        }

        public static void OneThread(int val) 
        {
            var res = FindFactorial(val);

            Console.WriteLine($"Факториал из {val}: {res}");
        }

        public static void Threading(IEnumerable<int> values)
        {
            foreach (var item in values)
            {
                Thread thread = new Thread(() => OneThread(item));
                thread.Start();
            }
        }
        
        public static void Start()
        {
            Console.WriteLine("Через пробел напишите числа");

            var nums = GetNumber();

            Threading(nums);
        }


        public static IEnumerable<int> GetNumber()
        {
            string str = Console.ReadLine();

            string[] arr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //var list = from i in arr
            //           where int.TryParse(i, out int _)
            //           select int.Parse(i);

            var list = arr
                .Where(x => int.TryParse(x, out int _))
                .Select(x => int.Parse(x));

            

            return list;
        }
    }
}
