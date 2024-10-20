using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.binary
{
    class Program()
    {
        public static void Start() 
        {
            int num = 20;
            string bin = ConvertIntToBin(num);

            Console.WriteLine(bin);

        }

        public static string ConvertIntToBin(int value, string bin = "") 
        {
            if(value == 0)
                return bin;

            bin = (value % 2) + bin;
            value /= 2;
            return ConvertIntToBin(value, bin);
        }
    }
}
