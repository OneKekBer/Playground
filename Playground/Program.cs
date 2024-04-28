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

            int currPage = 20;

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
                    Playground.pg._8.convert.Program.Start();
                    break;
                case 13:
                    Playground.pg._8.indexator.Program.Start();
                    break;
                case 14:
                    Playground.pg._8.reference.Program.Start();
                    break;
                case 15:
                    Playground.pg._8.extenstion.Program.Start();
                    break;
                case 16:
                    Playground.pg.del.delegat.Program.Start();
                    break;
                case 17:
                    Playground.pg._8.part.Program.Start();
                    break;
                case 18:
                    Playground.pg._8.anonimus.Program.Start();
                    break;
                case 19:
                    Playground.pg._8.record.Program.Start();
                    break;
                case 20:
                    Playground.pg._9_pattern_matching.type.Program.Start();
                    break;
                case 21:
                    break;
                case 22:
                    break;
                case 23:
                    break;
                case 24:
                    break;
                case 25:
                    break;
                case 26:
                    break;
                case 27:
                    break;
                case 28:
                    break;
                case 29:
                    break;
                case 30:
                    break;
                case 31:
                    break;
                case 32:
                    break;
                case 33:
                    break;
                case 34:
                    break;
                default:
                    break;
            }

            Console.ReadKey();


        }
    }
}

