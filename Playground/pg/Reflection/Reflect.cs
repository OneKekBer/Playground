using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Playground.pg.Reflection.Reflect
{
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(int edge)
        {
            Edge = edge;
        }

        public int Edge { get; init; }
    }

    public class CustomAttribute2 : Attribute
    {
        public CustomAttribute2(int edge)
        {
            Edge = edge;
        }

        public int Edge { get; init; }
    }

    abstract class Shape
    {
        protected Shape(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; init; }
        public int Width { get; init; }

        public virtual int GetArea()
        {
            return Height * Width;
        }
    }

    class Triangle : Shape
    {
        public Triangle(int height, int width) : base(height, width)
        {
        }

        public override int GetArea()
        {
            return Height * Width / 2;
        }
    }

    [CustomAttribute2(12)]

    [CustomAttribute(4)]
    class Square : Shape
    {
        public Square(int height, int width) : base(height, width)
        {
        }
    }

    public class Program
    {
        public static void Start()
        {
            var square = new Square(5, 5);
            Console.WriteLine($"Square Area: {square.GetArea()}");

            var triangle = new Triangle(5, 5);
            Console.WriteLine($"Triangle Area: {triangle.GetArea()}");

            var type = square.GetType();

            Console.WriteLine("Attributes:");
            foreach (var attr in type.GetCustomAttributesData())
            {
                Console.WriteLine($"Attribute Type: {attr.AttributeType}");

                if (attr.AttributeType == typeof(CustomAttribute))
                {
                    var edgeValue = attr.ConstructorArguments;
                    foreach(var ww in edgeValue)
                    {
                        Console.WriteLine(ww);
                    }
                }
            }

            Console.WriteLine("---------------");

            

            Console.WriteLine(type.GetFields());
            Console.WriteLine(type.GetFields().Length);


            foreach (var field in type.GetFields())
            {
                Console.WriteLine(field);
            }

            Console.WriteLine("---------------");


            Console.WriteLine(type.GetNestedTypes());
            Console.WriteLine(type.GetNestedTypes().Length);

            foreach (var field in type.GetNestedTypes())
            {
                Console.WriteLine(field);
            }


            Console.WriteLine("---------------");

            Console.WriteLine(type.BaseType);

            foreach (var field in type.BaseType.GetFields())
            {
                Console.WriteLine(field);
            }

        }
    }
}
