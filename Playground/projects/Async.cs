using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.async
{
    //class Program
    //{
    //    delegate void ActionsDelegate();


    //    public static void ThreadOne()
    //    {
    //        for (int i = 0; i < 80; i++)
    //        {
    //            Thread.Sleep(50);
    //            Console.Write(1);
    //        }
    //    }

    //    public static void ThreadThree()
    //    {
    //        for (int i = 0; i < 80; i++)
    //        {
    //            Thread.Sleep(50);
    //            Console.Write(3);
    //        }
    //    }

    //    public static void ThreadTwo()
    //    {
    //        for (int i = 0; i < 80; i++)
    //        {
    //            Thread.Sleep(50);
    //            Console.Write(" ! ");
    //        }
    //    }

    //    public static void Run()
    //    {
    //        ActionsDelegate actionsDelegate;

    //        actionsDelegate = ThreadOne;
    //        actionsDelegate += ThreadThree;

    //        Task task = new Task(new Action(actionsDelegate));


    //        task.Start();
    //        //or
    //        //Task.Run(ThreadOne)

    //        ThreadTwo();
    //        Console.ReadKey();
    //    }
    //}



    class PM
    {
        public static int ThreadInt()
        {
            return 1;
        }



        public delegate bool IsEqual(int val);

        public static bool Method(int val) => val == 3;


        public static void Run()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int res1 = Sum(arr, (val) => val == 3);

            int Sum(int[] arr, IsEqual func)
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

            ////////////////////////////


            //Task<int> task1 = new Task<int>(new Func<int>(ThreadInt));

            //task1.Start();

            //Console.WriteLine($"task1 result: {task1.Result}");


            //////////////////////////


            //var hello = () => Console.WriteLine("hello");

            //hello += () => Console.WriteLine("Mat szlucha");

            //hello += () => Console.WriteLine("Ebal");


            //void Method(int x, int y ) => Console.WriteLine(x + y);

            //hello();


            Console.ReadKey();
        }
    }

}
