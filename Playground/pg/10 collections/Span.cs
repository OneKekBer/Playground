using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._10_collections.span
{

    public class StorageHandler<T>
    {
        public T[] Storage { get; private set; }

        public StorageHandler(T[] storage)
        {
            Storage = storage;
        }

        public void GetData(T[] incomeData)
        {
            Span<T> span = new Span<T>(incomeData);

            foreach (var item in span)
            {
                Console.WriteLine(item);
            }
            Storage = span.ToArray();
        }

        public Span<T> GetSpan()
        {
            return Storage.AsSpan();
        }
    }

    internal class Program
    {

        public static void Start()
        {
            string[] str = ["hello world"];
            Span<string> span = new Span<string>(str);

            int[] intArr = [
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
                17,
                18,
                19,
                20,
            ];

            Span<int> intArrSpan = new Span<int>(intArr);

            Span<int> newSpan = intArrSpan.Slice(0, 10);

            foreach (int item in newSpan)
            {
                Console.WriteLine(item);
            }

            newSpan.Fill(23);

            foreach (int item in newSpan)
            {
                Console.WriteLine(item);
            }

            foreach (var item in span)
            {
                Console.WriteLine(item);
            }


            StorageHandler<string> storage = new StorageHandler<string>(["data", "wtfnepon", "message"]);

            Span<string> storageSpan = storage.GetSpan();

            foreach(var item in storageSpan)
            {
                Console.WriteLine(item);
            }


        }
    }
}
