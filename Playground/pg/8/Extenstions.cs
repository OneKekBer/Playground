using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.extenstion
{

    public static class StringExtension
    {
        public static int GetUltraLength(this string str)
        {
            return str.Length;
        }
    }

    public static class IntArrExtension
    {
        public static int GetMediana(this int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum / arr.Length;
        }
    }

    public static class IntExtension
    {
        public static int GetKube(this int x)
        {
            return x * x * x;
        }
    }

    internal class Program
    {
        public static void Start()
        {
            string str = "hello world";

            Console.WriteLine(str.GetUltraLength());

            int x = 5;

            Console.WriteLine(x.GetKube());

            int[] arr = { 1, 2, 3, 4, 5, 67, 8, 9, 10 };

            Console.WriteLine(arr.GetMediana());
        }
    }
}
