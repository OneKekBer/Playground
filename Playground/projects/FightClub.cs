using System;

namespace Project.fightclub
{

    interface ISkills
    {
        public void Punch();

        public void Ultimate();
    }
    class Game
    {
        public Game(Fighter fighter1, Fighter fighter2)
        {
            Fighter1 = fighter1;
            Fighter2 = fighter2;
            Console.WriteLine($"{Fighter1.Name} VS {Fighter2.Name}");
        }

        public Fighter Fighter1;
        public Fighter Fighter2;


        public void Fight()
        {
            while (Fighter1.HP > 0 || Fighter2.HP > 0)
            {

                Fighter1.GetIncomeDamage(Fighter2.Punch() > 0 ? Fighter2.Punch() : 0);//пиздюли получает fighter1
                Fighter2.GetIncomeDamage(Fighter2.Punch() > 0 ? Fighter2.Punch() : 0);//пиздюли получает fighter2



                Console.WriteLine($"HP {Fighter1.Name}: {Fighter1.HP} ");
                Console.WriteLine($"HP {Fighter2.Name}: {Fighter2.HP} ");

                //Console.WriteLine(Fighter1.GetHP());

                //Console.WriteLine(Fighter2.GetHP());

            }



        }


    }


    class Fighter
    {
        public int HP { get; set; }
        public int Damage { get; init; }
        public int Stamina { get; set; }
        public string Name { get; init; }


        public Fighter(int hp, int damage, int stamina, string name)
        {
            HP = hp;
            Damage = damage;
            Stamina = stamina;
            Name = name;
        }


        public void GetIncomeDamage(int incomeDamage)
        {
            HP -= incomeDamage;
        }

        public virtual int Punch()
        {
            if (!IsEnoughStamina(20)) return -1;
            return Damage;
        }

        public virtual int Ultimate()
        {
            if (!IsEnoughStamina(40)) return -1;
            return Damage + Damage;
        }

        public bool IsEnoughStamina(int neededStamina)
        {
            if (neededStamina < Stamina)
            {
                Stamina -= neededStamina;
                return true;
            }
            Console.WriteLine("Not enough stamina!! Damage equal 0");
            return false;

        }

    }



    class Karatee : Fighter
    {
        public Karatee(int hp, int damage, int stamina, string name) : base(hp, damage, stamina, name)
        {
        }

    }


    class Boxer : Fighter
    {
        public Boxer(int hp, int damage, int stamina, string name) : base(hp, damage, stamina, name)
        {
        }


    }

    class ListFighter
    {
        public Fighter[] fighters = new Fighter[] { new Boxer(100, 20, 100, "Boxer"), new Karatee(70, 25, 120, "Karatee") };

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

        public enum Players
        {
            First = 0,
            Second = 1,
        }

        public static void FightClub()
        {
            ListFighter listFighter = new ListFighter();
            Fighter[] allFighters = listFighter.GetAllFighters();


            Console.WriteLine("Choose your figter!");
            for (int i = 0; i < allFighters.Length; i++)
            {
                Console.WriteLine($"{i}: {allFighters[i].Name}");
            }



            Fighter firstFighter = ChooseFighter(Players.First, allFighters);

            Fighter secondFighter = ChooseFighter(Players.Second, allFighters);




            Game game = new Game(firstFighter, secondFighter);
            game.Fight();

            // Additional logic for the fight club
        }



        public static Fighter ChooseFighter(Players player, Fighter[] allFighters)
        {

            Console.WriteLine($"{player} fighter: ");

            int index = int.Parse(Console.ReadLine());
            if (index > allFighters.Length)
            {
                Console.WriteLine("There is no fighter!!");
                index = int.Parse(Console.ReadLine());
            }
            Fighter currentFighter = allFighters[index];
            return currentFighter;
        }
    }



}
