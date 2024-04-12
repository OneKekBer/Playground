using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.reference
{
    internal class Program
    {
        public static void Start()
        {
            Meth meth = new Meth(5);
            Test(meth);
            Console.WriteLine(meth);
            Test(meth);
            Test(meth);
        }
        public static void Test(Meth meth)
        {
            Console.WriteLine(meth.number);
            meth.number++;
            Console.WriteLine(meth.number);
        }
    }

    class Meth
    {
        public int number;

        public Meth(int num)
        {
            number = num;
        }
    }
}

