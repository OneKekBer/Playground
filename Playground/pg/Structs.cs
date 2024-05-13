using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.structs
{

    public record struct Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int Y, int X)
        {
            x = X;
            y = Y;
        }

        public static Coordinates operator +(Coordinates cord1, Coordinates cord2)
        {
            return new Coordinates(cord1.x + cord2.x, cord1.y + cord2.y);
        }
    }

    internal class Praogram
    {
        public static void Start()
        {
            Coordinates randomCords = new (2, 3);
            Coordinates nextCords = new (2, 3);


            Coordinates newCords = randomCords + nextCords;

            Console.WriteLine(newCords.x + " " + newCords.y);

            Console.WriteLine(nextCords == randomCords);
        }
    }
}
