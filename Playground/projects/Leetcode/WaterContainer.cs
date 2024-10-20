using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.Leetcode
{
    public class WaterContainer
    {
        public static void Start()
        {
            var arr = new int[] { 1 };
            Console.WriteLine(Work(arr)); 
        }

        private static int Work(int[] arr)
        {
            var maxVal = 0;

            var l = 0;
            var r = arr.Length - 1;

            while(l < r)
            {
                var minHeight = int.Min(arr[l], arr[r]);
                var distance = r - l;

                if(maxVal < minHeight* distance)
                    maxVal = minHeight * distance;

                if (arr[l] < arr[r])
                    l += 1;
                else
                    r -= 1;

            }

            return maxVal;
        }

        //private static void Work(int[] arr )
        //{
        //    var maxNum = 0;
            
        //    for(int i = 0; i < arr.Length; i++)
        //    {
        //        var firstNum = arr[i];
        //        for(int j = i; j < arr.Length; j++)
        //        {
        //            var nextNum = arr[j];

        //            var height = int.Min(firstNum, nextNum);

        //            var odp = height * Math.Abs(i - j );

        //            if (maxNum < odp)
        //            {
        //                Console.WriteLine("-----");
        //                Console.WriteLine($"i:{i}  j:{j}");
        //                Console.WriteLine($"firstNum: {firstNum} nextNum:{nextNum}");
        //                Console.WriteLine("height: " + height);
        //                Console.WriteLine(odp);
        //                maxNum = odp;
        //            }
                       

        //        }

        //    }
        //    Console.WriteLine(maxNum);
        //}
    }
}
