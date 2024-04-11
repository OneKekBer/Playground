using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.lambda
{
    class Program
    {
        public delegate bool IsEqual(int val);

        public static bool Method(int val) => val == 3;



        public static int Sum(int[] arr, IsEqual func)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (func(arr[i]))
                {
                    Console.WriteLine(arr[i]);
                    return arr[i];
                }
            }
            return 0;
        }


        public static void Start()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            int res1 = Sum(arr, (int val) => val == 3);

        }

    }
}
