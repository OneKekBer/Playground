using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._9_pattern_matching.list
{
    internal class Program
    {
        int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        string[] strArr = { "чубака", "дебчик", "репчик", "1 класс", "ядерная установка мендольсона" };


        static int OperateArr(int[] arr)
        {
            return arr switch
            {
                [_, 2] => 1,
                [_, 2, .., 1] => 2,
                [var first, .., var last] => first + last,
                [..] => -1
            };
        }

        public static void Start()
        {
            Console.WriteLine(OperateArr(new[] { 1,2, 2, 2,2, 1 , 4434 }));//2
        }
    }
}
