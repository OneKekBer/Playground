using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Playground.pg._8.operate
{
    //test1
    class Country
    {
        public int Population { get; set; }
        public int Area { get; set; }

        public static Country operator +(Country a, Country b)
        {
            a.Area = 43424234;


            return new Country() 
            { 
                Population = a.Population + b.Population,
                Area = a.Area + b.Area 
            };


        }
        public static bool operator <(Country country1, Country country2)
        {
            return country1.Population < country2.Population;
        }

        public static bool operator >(Country country1, Country country2)
        {
            return country1.Population > country2.Population;
        }

        public static bool operator true(Country country1) 
        {
            return true;
        }

        public static bool operator false(Country country1)
        {
            return false;
        }
    }

    //test2
    // хлеб
    public class Bread
    {
        public int Weight { get; set; } // масса

        public static Sandwich operator +(Bread bread, Butter butter)
        {
            return new Sandwich() { Weight = bread.Weight + butter.Weight };
        }
    }

    // масло
    public class Butter
    {
        public int Weight { get; set; } // масса
    }

    // бутерброт
    public class Sandwich
    {
        public int Weight { get; set; } // масса
    }


    internal class Program
    {

        public static void Test1()
        {
            Country belarus = new Country() { Population = 900, Area = 900 };
            Country poland = new Country() { Population = 2200, Area = 1800 };

            bool IsBelarusBigger = belarus > poland;

            Console.WriteLine(IsBelarusBigger);


            Country rpon = belarus + poland;

            Console.WriteLine(belarus.Area);
            Console.WriteLine(rpon.Area);
        }

        public static void Test2()
        {
            Bread bread = new Bread() { Weight = 80 };
            Butter butter = new Butter() { Weight = 20 };

            Sandwich sandwich = bread + butter;

            Console.WriteLine(sandwich.Weight);
        }


        

        public static void Test3()
        {
            int a = 4;
            int b = 5;

        }

        public static void Start()
        {
            Test1();
            Test2();
            Test3();
        }
    }
}
