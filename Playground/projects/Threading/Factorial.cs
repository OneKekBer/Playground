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
        public static int FindFactorial(int x, int sum = 1)
        {
            if (x == 0) return sum;
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
                Thread.Sleep(item * 10);
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

            var list = from i in arr
                       where int.TryParse(i, out int res)
                       select int.Parse(i);

            return list;
        }
    }
}
