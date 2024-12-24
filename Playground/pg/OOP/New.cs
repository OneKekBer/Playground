using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.OOP.New
{
    public class Program
    {
        class Person
        {
            public virtual void Speak()
            {
                Console.WriteLine("Я человек");
            }
        }

        class Programmer : Person 
        {
            public override void Speak()
            {
                Console.WriteLine("Kukareku");
            }
        }

        class Doctor : Person
        {
            public new void Speak()
            {
                Console.WriteLine("Give me 300 bucks");
            }
        }

        public static void Start()
        {
            Person person = new Person();
            person.Speak();

            Person prog = new Programmer();
            prog.Speak();

            Person doc = new Doctor();
            doc.Speak();

            Console.WriteLine("/////////");

            Programmer prog1 = new Programmer();
            prog1.Speak();

            Doctor doc1 = new Doctor();
            doc1.Speak();
        }
    }
}
