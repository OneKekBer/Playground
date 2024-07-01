using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._17_LINQ.group
{
    record class Person(string Name, string Company);

    class Program
    {
        public static void Start()
        {
            Person[] people =
            {
                new Person("Tom", "Microsoft"),
                new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"),
                new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"),
                new Person("Alice", "Microsoft"),
                new Person("Tommy", "Microsoft"),
                new Person("Sammy", "Google"),
                new Person("Bobby", "JetBrains"),
                new Person("Mikle", "Microsoft"),
                new Person("Kate", "JetBrains"),
                new Person("Alice", "Microsoft"),
            };

            var companies = people
                .DistinctBy(x => x.Name)
                .GroupBy(x => x.Company)
                .ToList();

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (var person in company)
                {
                    Console.WriteLine("-" + person.Name);
                }
                Console.WriteLine(); // для разделения между группами
            }
        }
    }
}
