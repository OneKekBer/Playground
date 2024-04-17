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


            int currPage = 7;

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
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:   
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                default:
                    break;
            }

            Console.ReadKey();


        }
    }
}

