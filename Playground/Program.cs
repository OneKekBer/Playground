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


            int currPage = 2;

            switch (currPage)
            {
                case 1:
                    Playground.lambda.Program.Start();
                    break;
                case 2:
                    Playground.events.Program.Start();
                    break;
                default:
                    break;
            }




        }
    }
}

