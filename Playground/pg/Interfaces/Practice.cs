using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.Interfaces.pract
{   

    interface IConst
    {
        public static string constanta = "string";
    }

    class Test : IConst 
    {
        public static void Meth()
        {
            string x = IConst.constanta;
        }
    }

    interface IMessage<T>
    {
        T Message { get; set; }
    }



    
    class Program
    {
        public static void Start()
        {
            Test test = new Test();
            Console.WriteLine(IConst.constanta);

            IConst.constanta = "auu";

            
            Console.WriteLine(IConst.constanta);

        }
    }
}
