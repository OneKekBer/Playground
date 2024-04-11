using System;

namespace Project.dice
{
    class Player
    {
        public int First;
        public int Second;

        public Player(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int GetSum()
        {
            return First + Second;
        }
    }


    public class Program
    {

        public static void Dice()
        {
            int money = 10;
            Random random = new Random();

            while (money > 0)
            {

                // Roll player's dice

                Player user = new(getRandomNum(), getRandomNum());
                int playerSum = user.GetSum();

                // Roll computer's dice

                Player computer = new Player(getRandomNum(), getRandomNum());
                int computerSum = computer.GetSum();


                Console.WriteLine($"Your Dice: {user.First} and {user.Second}");
                Console.WriteLine($"Computer's Dice: {computer.First} and {computer.Second}");

                if (playerSum > computerSum)
                {
                    money++;
                    Console.WriteLine("You won!!! +1 coin");
                }
                else
                {
                    money--;
                    Console.WriteLine("You lost!!! -1 coin");
                }
                Console.WriteLine($"Total Coins: {money}");
                Console.WriteLine("Continue? (y/n)");
                string input = Console.ReadLine();
                if (input.ToLower() != "y")
                    break; // Exit the loop if the input is not "yes"
            }

            int getRandomNum()
            {
                Random random = new Random();
                return random.Next(1, 6);
            }

            Console.WriteLine("Game Over!");
        }
    }
}
