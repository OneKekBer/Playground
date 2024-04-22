using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._8.indexator
{

    public interface IClass
    {
        public int this[int x]
        {
            get
            {
                return 0;
            }
        }
    }

    //test1
    class Product
    {
        public string Name { get; set; }

        public Product(string name) => Name = name;
    }

    class Shop
    {
        public Shop(Product[] List) => list = List;

        public Product[] list = new Product[2];

        public Product this[int index]
        {
            get => list[index];
        }

        public Product this[string name]
        {
            get 
            {
                foreach (var item in list) 
                {
                    if (item.Name == name) return item;
                }
                throw new Exception("cant find this bullshit!");
            }
        }

    }

    //test2

    class Zawdonik
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Zawdonik(string name, int num) 
        { 
            Name = name; 
            Number = num;
        }
    }

    class Team
    {

        public Zawdonik[] teamList = new Zawdonik[4];
        public Team(Zawdonik[] zawdoniks) => teamList = zawdoniks;

        public Zawdonik this[int index]
        {
            //это не правильно и ты хуесос))))
            //get 
            //{
            //    try
            //    {
            //        return teamList[index];
            //    }
            //    catch
            //    {
            //        return null;
            //        throw new IndexOutOfRangeException("ooops...");

            //    }
            //}
            get
            {
                if(index >= 0 && index <= teamList.Length)
                {
                    return teamList[index];
                }
                return null;
            }
        }
    }


    //test3


    class Word
    {
        public string Source { get; }
        public string Target { get; set; }
        public Word(string source, string target)
        {
            Source = source;
            Target = target;
        }
    }
    class Dictionary
    {
        Word[] words;
        public Dictionary()
        {
            words = new Word[]
            {
            new Word("red", "красный"),
            new Word("blue", "синий"),
            new Word("green", "зеленый")
            };
        }

        public Word this[string word]
        {
            get
            {
                foreach (Word item in words)
                {
                    if(item.Source == word)
                    {
                        return item;
                    }
                }
                return null;
            }

            set
            {
                foreach (Word item in words)
                {
                    if (item.Source == word)
                    {
                        item.Target = word;
                    }
                }
            }
        }

        

    }

    internal class Program
    {

        public static void Test1()
        {
            Shop lidl = new Shop(new[] {
                new Product("MAYONAISE"), new Product("EGGS")
            });


            Console.WriteLine(lidl[0].Name);

            Console.WriteLine(lidl["MAYONAISE"].Name);
        }

        public static void Test2()
        {
            Team team = new Team(new Zawdonik[] { new Zawdonik("messi", 11), new Zawdonik("ronaldo", 5), new Zawdonik("lewandowski", 12) });

            Zawdonik zaw = team[200];

            Console.WriteLine(zaw != null ? zaw.Name : "There is no zawodnik with this index...");


            //Console.WriteLine(team[1].Name);
        }

        public static void Test3()
        {
            Dictionary dick = new Dictionary();

            Console.WriteLine(dick["blue"].Target);
        }

        public static void Start() 
        {
            //Test2();
            Test3();
        }

    }
}
