using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.part
{

    partial class Human
    {
        public void Walk()
        {
            Console.WriteLine("Im walking dead!!!");
        }

        public partial void Read();
        public void DoSomething()
        {
            Console.WriteLine("Im doing smth!!");
            Read();
        }


    }


    partial class Human
    {

        public partial void Read()
        {
            Console.WriteLine("I am reading a book");
        }

        public void Jump()
        {
            Console.WriteLine("Im mario!!!");
        }
    }


    internal class Program
    {
        public static void Start()
        {
            Human human = new Human();

            human.Walk();
            human.Jump();
            human.DoSomething();
        }
    }
}
