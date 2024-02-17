using System;

public class Dice
{

    class Player
    {
        int first;
        int second;
        public Player(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        int getSum()
        {


        }
    }
    public static void Main()
    {



        int money = 10;
        while (true)
        {

            if (money < 0)
            {
                Console.WriteLine("Ты проебал!!!");
                break;
            }

            int getRandomNumber()
            {
                Random random = new Random();
                return random.Next(1, 6);
            }


            int computerFirst = random.Next(1, 6);
            int computerSecond = random.Next(1, 6);
            int computerSum = computerFirst + computerSecond;



            Console.WriteLine($"Твои Кубики: {playerFirst} и {playerSecond}");
            Console.WriteLine($"Кубики врага: {computerFirst} и {computerSecond}");

            if (playerSum > computerSum)
            {
                money++;
                Console.WriteLine("Ты выиграл!!! + 1 монета");
                Console.WriteLine($"Всего Монет:{money}");
            }
            else
            {
                money--;
                Console.WriteLine("Ты проиграл!!! - 1 монета");
                Console.WriteLine($"Всего Монет:{money}");
            }
            Console.WriteLine("Продолжить??");
            string s = Console.ReadLine();
        }

    }
}