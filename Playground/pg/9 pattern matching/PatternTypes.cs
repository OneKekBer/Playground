using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._9_pattern_matching.type
{
    public class Empolyee
    {
        public virtual void Work()
        {
            Console.WriteLine("Rabotyaga workaet");
        }
    }

    public class Manager : Empolyee
    {
        public override void Work()
        {
            Console.WriteLine("Manipulate rabotaya");
        }

        public Manager(bool isEmuPohui) => IsEmuPohui = isEmuPohui;

        public bool IsEmuPohui;
    }

    public class Boss : Empolyee
    {
        public override void Work()
        {
            Console.WriteLine("Boss blyat rabotat nie budet ");
        }
    }


    public class Job()
    {
        public void WorkTime(Empolyee empolyee)
        {
            if (empolyee is Manager manager && manager.IsEmuPohui == true)
            {
                Console.WriteLine("менеджеру похуй, отъебись");
            }
            else if (empolyee is Boss boss)
            {
                Console.WriteLine("ты рофлишь?!");
            }
            else
            {
                empolyee.Work();
            }

            //empolyee.Work();
        }
    }


    internal class Program
    {
        public static void Start()
        {
            Job zawod = new Job();

            zawod.WorkTime(new Manager(false));
        }
    }
}
