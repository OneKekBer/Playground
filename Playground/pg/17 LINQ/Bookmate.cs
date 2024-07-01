using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._17_LINQ.bookmate
{
    enum Genres
    {
        Action = 0,
        Detective = 1,
        Romantic = 2,
        SCFI = 3,
        Fantasy = 4
    }

    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public Genres Genre { get; set; }
    }

    internal class Program
    {
        public static void PrintList(IEnumerable<Book> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id} - {item.Title} - {item.Author} - {item.Year} - {item.Genre} - {item.Pages}");
            }

            Console.WriteLine("---------------------------------------------------");
        }

        public struct YearAndPage
        {
            public int Year { get; set; }
            public int Pages { get; set; }
        }

        public static void PagesOnEveryYear(IEnumerable<Book> list)
        {
            var allUYears = list
                .Select(x => x.Year)
                .Distinct()
                .Order()
                .ToList();

            foreach (var item in allUYears)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------------");
            var pagesOnEveryYear = list
                .GroupBy(book => book.Year)
                .SelectMany(g => g
                    .Select(book => new YearAndPage { Year = g.Key, Pages = book.Pages })
                )
                .OrderBy(x => x.Year)
                .Distinct()
                .ToList();

            foreach (var item in pagesOnEveryYear)
            {
                Console.WriteLine($"{item.Year} -- {item.Pages}");
            }
        }

        public static void Start()
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien", Year = 1954, Pages = 423, Genre = Genres.Fantasy },
                new Book { Title = "Dune", Author = "Frank Herbert", Year = 1965, Pages = 412, Genre = Genres.SCFI },
                new Book { Title = "The Da Vinci Code", Author = "Dan Brown", Year = 2003, Pages = 454, Genre = Genres.Detective },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, Pages = 279, Genre = Genres.Romantic },
                new Book { Title = "1984", Author = "George Orwell", Year = 1949, Pages = 328, Genre = Genres.SCFI },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, Pages = 218, Genre = Genres.Romantic },
                new Book { Title = "Murder on the Orient Express", Author = "Agatha Christie", Year = 1934, Pages = 256, Genre = Genres.Detective },
                new Book { Title = "The Hunger Games", Author = "Suzanne Collins", Year = 2008, Pages = 374, Genre = Genres.Action },
                new Book { Title = "The Name of the Wind", Author = "Patrick Rothfuss", Year = 2007, Pages = 662, Genre = Genres.Fantasy },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, Pages = 279, Genre = Genres.Romantic },
                new Book { Title = "1984", Author = "George Orwell", Year = 1949, Pages = 328, Genre = Genres.SCFI },
                new Book { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Year = 1997, Pages = 309, Genre = Genres.Fantasy },
            };

            //var allFantasies = books
            //    .OrderBy(book => book.Year)
            //    .Where(book => book.Genre == Genres.Fantasy)
            //    .ToList();

            ////PrintList(allFantasies);

            //var biggestBookPages = books
            //    .Max(book => book.Pages);

            //var biggestBook = books
            //    .Where(book => book.Pages == biggestBookPages)
            //    .ToList();

            //PrintList(biggestBook);

            //var averageOfPages = books
            //    .Average(book => book.Pages);

            //Console.WriteLine(averageOfPages);

            //var booksAfterTwenties = books
            //    .Where(book => book.Year >= 2000)
            //    .ToList();

            //PrintList(booksAfterTwenties);

            //var pagesOfAllDetectives = books
            //    .Where(book => book.Genre == Genres.Fantasy)
            //    .Sum(book => book.Pages);

            //Console.WriteLine(pagesOfAllDetectives);

            PagesOnEveryYear(books);
        }
    }
}
