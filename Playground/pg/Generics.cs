using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.generics
{

    class General<T>
    {

        public General(T[] arr) 
        {
            this.arr = arr;
        }

        

        public T[] arr;

        public T GetValueFromArr(int index) => arr[index];
        
        public void AddValueToArr(int index, T value)
        {
            arr[index] = value;
            Console.WriteLine(arr[index]);
        }

        public void GetArrLength() => Console.WriteLine(arr.Length);

        
    }

    internal class Program
    {

        public static void PrintArr<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void Start()
        {
            General<int> gen = new General<int>( new int[] { 1, 2 ,3 ,4 ,5 });

            PrintArr(gen.arr);

            gen.AddValueToArr(1, 2);

            PrintArr(gen.arr);


        }
    }
}
