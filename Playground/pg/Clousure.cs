using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.closure
{
    internal class Program
    {
        public static void Start()
        {

            //var close = () =>
            //{
            //    int x = 5;
            //    var func = () => Console.WriteLine(++x);
            //    return func;
            //};

            //var fn = close();

            //fn();
            //fn();
            //fn();   
            //fn();



            //var counter = CounterHandler();

            //Console.WriteLine(counter());
            //Console.WriteLine(counter());
            //Console.WriteLine(counter());



            //List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };

            //names.Sort((x, y) => x.Length.CompareTo(y.Length));

            //Console.WriteLine(string.Join(", ", names));




            //Func<int, int> factorial = null;

            //factorial = (n) => n == 0 ? 1 : n * factorial(n - 1);

            //Console.WriteLine(factorial(5)); // Выведет 120 (факториал числа 5)

            //Console.ReadKey();


            
        }

        // let s = 1
        // const getFact = (n) => {
        //    if (n === 0) {
        //       return s
        //    }
        //    else {
        //       s *= n
        //       return getFact(n - 1)
        //    }
        // }
        // const res = getFact(8)
        // console.log(res)



        

        
        //static Func<int> CounterHandler()
        //{
        //    int counter = 0;

        //    //variant 1

        //    //var count = () => counter++
        //    //return count;


        //    //variant 2
            
        //    return () =>
        //    {
        //        counter++;
        //        return counter;
        //    };
        //}
          
    }
    
}

