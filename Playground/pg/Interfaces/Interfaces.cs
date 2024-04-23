using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Playground.pg.inter.Interfaces
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



    //public interface ISwim 
    //{
    //    public void Swim();

    //}

    //public interface IJump 
    //{
    //    public void Jump();
    //}

    //public interface IBoth
    //{
    //    public void Swim();


    //    public void Jump();
    //}

    //public interface IAction
    //{
    //    public int Act(int val)
    //    {
    //        return val += 341322;
    //    }
    //}

    //interface Icont : IAction
    //{
    //    public new int Act(int val)
    //    {
    //        return val += 3;
    //    }
    //}


    //class Human : IJump, ISwim, IBoth
    //{


    //    void IJump.Jump() => Console.WriteLine("jump");


    //    void ISwim.Swim()
    //    {
    //        Console.WriteLine("swim");
    //    }

    //    public void Jump()
    //    {
    //        Console.WriteLine("default jump");
    //    }

    //    public void Swim()
    //    {
    //        Console.WriteLine("default SWIM");
    //    }
    //}

    //class Actor : IAction
    //{
    //    public int Act(int val)
    //    {
    //        return val;
    //    }
    //}


    //public interface ICar
    //{
    //    public void Run()
    //    {
    //        Console.WriteLine("I am going to aszchabad");
    //    }
    //}
    //public interface IMBW : ICar
    //{
    //    void BMW()
    //    {
    //        Console.WriteLine("BMW");

    //    }
    //}

    //interface IMers : ICar
    //{

    //    void Mers()
    //    {
    //        Console.WriteLine("MERS");
    //    }
    //}

    //class Auto<T> where T : IMBW, IMers
    //{
    //    public void Run(T arg)
    //    {
    //        arg.Run();
    //    }

    //}

    //class BMW : IMBW
    //{

    //}



    //----------------


    interface IMessage
    {
        string Text { get; } // текст сообщения
    }
    interface IPrintable
    {
        void Print();
    }
    class Message : IMessage, IPrintable
    {
        public string Text { get; }
        public Message(string text) => Text = text;

        public void Print() => Console.WriteLine(Text);
    }

    class Messenger<T> where T : IMessage, IPrintable
    {
        public void Send(T message)
        {
            Console.WriteLine("Отправка сообщения:");
            message.Print();
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
            //Human human = new Human();

            //((IJump)human).Jump();

            ////human.Swim();

            //IMBW bmw = new BMW();

            ////Auto<IMBW> auto = new Auto<IMBW>();


        }

        public static void PrintArray<T>(IList<T> arr)
        {
            foreach(var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static void Test3()
        {
            Messenger<Message> tg = new Messenger<Message>();

            var message = new Message("Idz do pizdy!!!");

            tg.Send(message);
        }

        public static void Test4()
        {
            int[] arr = { 1, 2, 4, 4, 5, 6, 7, 8 };

            
            PrintArray(arr);

            string[] arr2 = { "sdaf", "fsafa" };

            PrintArray(arr2);


            List<int> list = new List<int>() { 412, 41, 6432, 231 };

            PrintArray(list);

        }


        public static void Start()
        {
            //Test1();
            //Test2();
            //Test3();
            Test4();

        }
    }
}
