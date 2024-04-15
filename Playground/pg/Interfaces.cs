using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.interfaces
{
    //public interface ICar
    //{
    //    string Name { get; }

    //    int Engine { get; }
    //}

    //class Car : ICar
    //{
    //    public string name;

    //    public int engine;

    //    public string Name => name;

    //    public int Engine => engine;
    //}

    //public interface IFaggot
    //{
    //    public static int maxSpeed = 60;
    //    public int GetPenetrate();
    //    public int Abst { get; set; }

    //    public const int val = 5;

    //    public static int vall;

    //    public int Speak(int val) //default call
    //    {
    //        Console.WriteLine(val);
    //        return val;
    //    }

    //}

    //class Faggot : IFaggot
    //{

    //    public int Abst { get; set; }
    //    //public int Abst { get => ; set => throw new NotImplementedException(); }

    //    public Faggot(int abst)
    //    {
    //        Abst = abst;
    //    }

    //    public int GetPenetrate()
    //    {
    //        return 5;
    //    }
    //}



    public interface ISwim 
    {
        public void Swim();
        
    }

    public interface IJump 
    {
        public void Jump();
    }

    public interface IBoth
    {
        public void Swim();


        public void Jump();
    }


    class Human : IJump, ISwim, IBoth
    {

        
        void IJump.Jump() => Console.WriteLine("jump");
        

        void ISwim.Swim()
        {
            Console.WriteLine("swim");
        }

        public void Jump()
        {
            Console.WriteLine("default jump");
        }

        public void Swim()
        {
            Console.WriteLine("default SWIM");
        }
    }


    internal class Program
    {

        public static void Test1()
        {
            ////разницы нет 
            //ICar carr = new Car();
            //Car car = new Car();



            //Faggot faggot = new Faggot(4);

            //Console.WriteLine(faggot.Abst);

            //Console.WriteLine(IFaggot.maxSpeed);

            //FaggotDetective(faggot);
        }

        public static void Test2() 
        {
            Human human = new Human();

            ((IJump)human).Jump();

            //human.Swim();



        }


        public static void Start()
        {
            Test1();
            Test2();


        }
    }
}
