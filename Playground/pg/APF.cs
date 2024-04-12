using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Playground.apf
{
    internal class Program
    {
        public static void Start()
        {

            void Calculator(int x, int y, Action<int,int> act) => act(x, y);


            Calculator(2, 5, Sum);

            void Sum(int x, int y) => Console.WriteLine(x + y);



            Func<int, int[]> hello = (x) =>
            {
                int[] arr = new int[x];

                for (int i = 0; i < x; i++)
                {
                    arr[i] = i;
                }

                return arr;
            };


            int[] res = hello(5);


            Handler(res, (x) =>
            {
                return x % 2 == 0;
            });

            //Handler(res, Pred);


        }


        public static bool Pred(int x)
        {
            return x % 2 == 0;
        }

        public static int[] hello(int x)
        {
            int[] arr = new int[x];

            for (int i = 0; i < x; i++)
            {
                arr[i] = i;
            }

            return arr;
        }

        static void Handler(int[] arr, Predicate<int> func)
        {
            foreach (int val in arr) 
            {
                if (func(val))
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}
