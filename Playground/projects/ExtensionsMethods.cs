using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.ExtensionsMethods
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }

    public static class ShapeExtension
    {
        public static bool IsTriangle (this Shape shape)
        {
            if(shape.Name == "triangle")
                return true;
            return false;
        }
    }

    public class Shape
    {
        public Shape(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class Program
    {

        public static void Start()
        {
            var triangle = new Shape("triangle");

            Console.WriteLine(triangle.IsTriangle());
        }
    }
}
