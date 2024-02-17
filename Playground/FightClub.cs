using System;

namespace FightClub
{
    class Game
    {
        public Game(Fighter fighter1, Fighter fighter2)
        {
            Fighter1 = fighter1;
            Fighter2 = fighter2;
        }

        public Fighter Fighter1;
        public Fighter Fighter2;
    }

    class Fighter
    {
        private int HP;
        private int Damage;
        private int Stamina;
        private string Name;


        public Fighter(int hp, int damage, int stamina, string name)
        {
            HP = hp;
            Damage = damage;
            Stamina = stamina;
            Name = name;
        }

        public int GetHP() { return HP; }
        public int GetDamage() { return Damage; }
        public string GetName() { return Name; }
        public int GetStamina() { return Stamina; }

        public virtual void Punch()
        {
            Console.WriteLine("The fighter is winding up...");
        }
    }



    class Karatee : Fighter
    {
        public Karatee(int hp, int damage, int stamina, string name) : base(hp, damage, stamina, name)
        {
        }

        public override void Punch()
        {
            base.Punch();
            Console.WriteLine("The karatee throws a punch!");
        }
    }


    class Boxer : Fighter
    {
        public Boxer(int hp, int damage, int stamina, string name) : base(hp, damage, stamina, name)
        {
        }

        public override void Punch()
        {
            base.Punch();
            Console.WriteLine("The boxer throws a punch!");
        }
    }

    class ListFighter
    {
        public Fighter[] fighters = new Fighter[] { new Boxer(100, 20, 100, "Boxer"), new Karatee(70, 40, 120, "Karatee") };

        public Fighter[] GetAllFighters()
        {
            return fighters;
        }
    }

    class Program
    {
        public static void MainFight()
        {
            FightClub();
        }

        public static void FightClub()
        {
            ListFighter listFighter = new ListFighter();
            Fighter[] allFighters = listFighter.GetAllFighters();

            Console.WriteLine("Choose your figter!");
            for(int i = 0; i < allFighters.Length; i++)
            {
                Console.WriteLine($"{i}: {allFighters[i].GetName()}");
            }
            Console.Write("First fighter: ");
            string firstFighter = Console.ReadLine();


            Game game = new Game();
            

            // Additional logic for the fight club
        }
    }
}
