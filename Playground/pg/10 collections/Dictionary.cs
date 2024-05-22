using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._10_collections.dictionary
{
    internal class Program
    {

        public static void RemoveBook(Library library)
        {
            Console.WriteLine("write index of book what you what to remove");
            int index = int.Parse(Console.ReadLine());
            library.RemoveBook(index);
        }

        public static void Start()
        {
            Library library = new Library();

            library.AddBook(new Book("1984"));
            library.AddBook(new Book("Elder ring"));
            library.AddBook(new Book("hogwarts"));

            library.PrintAllBooks();

            RemoveBook(library);


            library.PrintAllBooks();

            library.AddBook(new Book("Heros never die"));
            library.AddBook(new Book("Lord of the ring"));
            library.AddBook(new Book("Warriors"));

            Console.WriteLine("//");

            library.PrintAllBooks();

            RemoveBook(library);

            library.PrintAllBooks();


            Console.ReadKey();
        }
    }

    struct Book
    {
        public string Title { get; private set; }

        public Book (string title)
        {
            Title = title;
        }
    }


    class Library
    {
        Dictionary<int, Book> libraryStorage = new Dictionary<int, Book>();


        public int FindMaxStorageKey()
        {
            int currIndex = 0;
            if (libraryStorage.Count == 0)
                return 0;

            foreach (var item in libraryStorage)
            {
                if(item.Key - currIndex == 1)
                {
                    currIndex++;
                }
                else
                {
                    return currIndex;
                }
            }

            return currIndex;
        }

        public void AddBook(Book newBook)
        {
            int newKey = FindMaxStorageKey() + 1;
            libraryStorage.Add(newKey, newBook);
        }

        public void RemoveBook(int key)
        {
            libraryStorage.Remove(key);
        }

        public void PrintAllBooks()
        {
            foreach (var item in libraryStorage)
            {
                Console.WriteLine($"key:{item.Key} title:{item.Value.Title}");
            }
        }
    }
}
