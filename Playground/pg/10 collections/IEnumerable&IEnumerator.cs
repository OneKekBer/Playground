//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Playground.pg._10_collections.ienum
//{

//    class List : IEnumerator
//    {

//        public List<string> list;
//        public int index;
//        public object Current => throw new NotImplementedException();

//        public bool MoveNext()
//        {
//            index++;
//        }

//        public void Reset()
//        {
//            index = 0;
//        }
//    }


//    class Product
//    {
//        public string Name { get; set; }

//        public Product(string name)
//        {
//            Name = name;
//        }
//    }
     
//    class Shop : IEnumerable
//    {
//        public Product[] products { get; set; }
//        public int position = 0;

//        public Shop(Product[] products)
//        {
//            this.products = products;
//            //this.position = position;
//        }

//        public IEnumerator GetEnumerator() => products.GetEnumerator();
//    }

//    internal class Program
//    {
//        public static void Method1()
//        {
//            string[] people = { "tom", "bob", "ilja" };

//            IEnumerator peopleEnumerator = people.GetEnumerator();

//            while (peopleEnumerator.MoveNext())
//            {
//                string item = (string)peopleEnumerator.Current;
//                Console.WriteLine(item);
//            }
//            peopleEnumerator.Reset();
//        }

//        public static void Method2()
//        {
//            Shop lidl = new Shop(new Product[] 
//            {
//                new Product("Apple"),
//                new Product("Banan"),
//                new Product("Meat")

//            });

//            foreach(Product product in lidl)
//            {
//                Console.WriteLine(product.Name);
//            }
//        }

//        public static void Method3()
//        {

//        }

//        public static void Start()
//        {
//            Method2();
//        }
//    }
//}
