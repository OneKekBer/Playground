using System;

namespace Playground.pg.inter.IComparable
{
    class Human : IComparable<Human>
    {
        public string name;
        public int age;

        public Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Human? o)
        {
            if (o == null) return 1; // Consider null as greater

            if (this.age > o.age)
                return 1;
            if (this.age < o.age)
                return -1;
            return 0;
        }
    }

    public class HumanComparer : IComparer<Human>
    {
        int IComparer<Human>.Compare(Human? x, Human? y)
        {
            if(x == null || y == null) return 1;

            if (x.age < y.age) 
                return 1;
            if(x.age > y.age)
                return -1;
            return 0;
        }
    }

    internal interface Program
    {
        public static void Start()
        {
            HumanComparer humanComparer = new HumanComparer();

            Human tom = new Human("Tom", 22);
            Human ben = new Human("Ben", 31);
            Human jerry = new Human("Jerry", 18);
            Human ilja = new Human("Ilja", 65);

            Human[] arr = new Human[] { tom, ben, jerry, ilja };

            Array.Sort(arr, humanComparer);

            foreach (var human in arr)
            {
                Console.WriteLine($"{human.name}: {human.age}");
            }
        }
    }
}
