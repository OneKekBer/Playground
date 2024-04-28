using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.record
{
    public record class Anonim
    {
        public string Name;

        public Anonim(string name) 
        {
            Name = name;
        }

    }

    public record Car
    {
        public string Name;

        public int CurrentFuel;

        public Car(string name, int currFuel)
        {
            Name = name;
            CurrentFuel = currFuel;
        }

        public void Deconstruct(out string name, out int currFuel) => (name, currFuel) = (Name, CurrentFuel);

    }

    internal class Program
    {

        public static void Start()
        {
            Car kurwaBobr = new Car("Mitsubishi", 40);


            var (kurwaName, kurwaFuel) = kurwaBobr;

            Console.WriteLine(kurwaName + kurwaFuel);


            Anonim anonim = new Anonim("joe");
            anonim.Name = "avrelii";

                 
            //true
            var anotni = anonim with { Name = "avrelii" }; // create new object based on exstising obj
            Console.WriteLine(anonim.Equals(anotni));

            //false 
            var anotniu = anonim with { Name = "joshua" };
            Console.WriteLine(anonim.Equals(anotniu));

            //
            Console.WriteLine(anotni.Name);
        }
    }
}
