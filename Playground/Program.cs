// See https://aka.ms/new-console-template for more information

//using Dice;
//using Auth;
//using FightClub;
//using TestNamespace;
using Playground.lambda;
using System.Text;




namespace MainVV
{

    class Class
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            int currPage = 11;

            switch (currPage)
            {
                case 1:
                    Playground.lambda.Program.Start();
                    break;
                case 2:
                    Playground.events.Program.Start();
                    break;
                case 3:
                    Playground.apf.Program.Start();
                    break;
                case 4:
                    Playground.closure.Program.Start();
                    break;
                case 5:
                    Playground.pg.inter.Interfaces.Program.Start();
                    break;
                case 6:
                    Playground.generics.Program.Start();
                    break;
                case 7:
                    Playground.pg.inter.amazon.Program.Start();
                    break;
                case 8:
                    Playground.pg.inter.iclone.Program.Start();
                    break;
                case 9:
                    Playground.pg.inter.IComparable.Program.Start();
                    break;
                case 10:
                    Playground.pg.inter.korvariant.Program.Start();
                    break;
                case 11:
                    Playground.pg._8.operate.Program.Start();
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                default:
                    break;
            }

            Console.ReadKey();


        }
    }
}

