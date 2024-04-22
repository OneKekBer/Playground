using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.reference
{
    internal class Program
    {       
        public static ref int FindInArray(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                    return ref arr[i];
            }
            throw new IndexOutOfRangeException("tobi pizda");
        }

        public static void PrintArray<T>(T[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static void CoolMethod(ref int x)
        {
            x = 1000000000;
        }

        public static void Start() 
        {
            int[] arr = { 0, 1, 2, 3, 45, 5, 4324, 61, 51, 6, 342, 7, 8, 43, 543, 43, 543, 53, };

            ref int arrRef = ref FindInArray(arr, 5);

            Console.WriteLine(arrRef);

            arrRef = 51;

            PrintArray(arr);

            Console.WriteLine();

            int y = 4;

            CoolMethod(ref y);

            Console.WriteLine(y);
        }

    }
}
