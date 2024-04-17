using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.inter.iclone
{

    class Work
    {
        public string name;

        public int salary;

        public Work(string name, int salary)
        {
            this.name = name;
            this.salary = salary;
        }
    }
    class Human : ICloneable
    {
        public string name;
        public int age;
        public Work work;

        public Human(string name, int age, Work work)
        {
            this.name = name;
            this.age = age;
            this.work = work;
        }

        public object Clone()
        {
            return new Human(name, age, new Work(work.name, work.salary));
        }
    }

    internal interface Program
    {
        public static void Start()
        {
            Human Tate = new Human("tate", 24, new Work("microsoft", 100000));
            //Human Tate = new Human("tate", 24);


            var Bob = (Human)Tate.Clone();

            Bob.name = "Bob";

            Bob.work.name = "Apple";

            Console.WriteLine(Tate.name);
            Console.WriteLine(Bob.name);

            Console.WriteLine(Tate.work.name);
            Console.WriteLine(Bob.work.name);


        }

    }
}
