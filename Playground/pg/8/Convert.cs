using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.convert
{
    class Rouble 
    {
        public int Value {  get; set; }
    }
    class Euro 
    {
        public int Value { get; set; }

        public static implicit operator Rouble(Euro eur)
        {
            return new Rouble() { Value = eur.Value * 32 };
        }

        public static explicit operator Euro(Rouble rouble)
        {
            return new Euro() { Value = rouble.Value / 32 };
        }
    }

    //test2
    class Clock
    {
        public int Hours { get; set; }

        public static implicit operator Clock(int x)
        {
            return new Clock() { Hours = x };
        }

        public static explicit operator int(Clock x)
        {
            return x.Hours;
        }
    }

    //test3

    

    class Celcius
    {
        public double Gradus { get; set; }

        public static explicit operator Celcius(Fahrenheit far)
        {
            return new Celcius() { Gradus = 5d/9d * (far.Gradus - 32) };
        }

        public static explicit operator Fahrenheit(Celcius cel)
        {
            return new Fahrenheit() { Gradus = 9d /5d * cel.Gradus + 32 };
        }

    }
    class Fahrenheit
    {
        public double Gradus { get; set; }

    }
    

    internal class Program
    {
        public static void Test3()
        {
            Celcius cel = new Celcius() { Gradus = 36 };

            var far = (Fahrenheit)cel;

            

            Console.WriteLine(far.Gradus);

        }
        public static void Test1()
        {
            Euro euro = new Euro() { Value = 20 };

            Rouble rouble = euro;

            Euro er = (Euro)rouble;

            Console.WriteLine(er.Value);


            Console.WriteLine(rouble.Value);
        }
        public static void Start()
        {
            Test3();

        }

    }
}
