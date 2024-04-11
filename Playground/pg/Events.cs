using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Playground.events
{

    
    
    //class Account
    //{
    //    public delegate void AccountHandler(string text);

    //    AccountHandler? onAccountChanged;

    //    public event AccountHandler? OnAccountChanged
    //    {
    //        add
    //        {
    //            onAccountChanged += value;
    //            Console.WriteLine($"{value.Method.Name} добавлен");
    //        }
    //        remove
    //        {
    //            onAccountChanged -= value;
    //            Console.WriteLine($"{value.Method.Name} удален");
    //        }
    //    }


    //    // сумма на счете
    //    public int Sum { get; private set; }
    //    // в конструкторе устанавливаем начальную сумму на счете
    //    public Account(int sum) => Sum = sum;
    //    // добавление средств на счет
    //    public void Put(int sum)
    //    {
    //        Sum += sum;
    //        onAccountChanged?.Invoke($"Положили {sum}");
    //    }
    //    // списание средств со счета
    //    public void Take(int sum)
    //    {
    //        if (Sum >= sum)
    //        {
    //            Sum -= sum;
    //            onAccountChanged?.Invoke($"Сняли {sum}");
    //        }
    //    }
    //}


    //class Program
    //{

    //    public static void Start()
    //    {
    //        Account acc = new Account(1000);

    //        acc.OnAccountChanged += Notify;

    //        acc.Take(50);
    //        acc.Put(50);

    //        Console.WriteLine(acc.Sum);
    //        Console.ReadKey();
    //    }

    //    public static void Notify(string text) 
    //    {
    //        //Thread.Sleep(1000);
    //        //Console.WriteLine("Ебать сложные вычисления ");
    //        //Thread.Sleep(1000);
    //        //Console.WriteLine("Вычисляю...... ");
    //        //Thread.Sleep(1000);
    //        Console.WriteLine(text);


    //    }
    //}

    //-------------------------------------------------
    

    class Caffee
    {
        public delegate void CaffeeHandler(string msg);

        public event CaffeeHandler? Notify;

        public int FreeSpots;

        public int OccupSpots = 0;

        public Caffee(int FreeSpots) 
        {
            this.FreeSpots = FreeSpots;
        } 

        public void NewCustomers(int customers)
        {
            if (customers <= FreeSpots)
            {
                FreeSpots -= customers; 
                OccupSpots += customers;
                Notify?.Invoke($"Пришли гости: {customers}");
                return;

            }
            Notify?.Invoke($"Пришли гости но мест не хватило: {customers}");
        }

        public void CustomersGone(int customers)
        {
            FreeSpots += customers;
            OccupSpots -= customers;

            Notify?.Invoke($"Гости ушли: {customers}");
        }
    }

    class Program
    {
        public static void NotifySystem(string text)
        {
            Console.WriteLine(text);
        }

        public static void Start()
        {
            Caffee caffee = new Caffee(10);

            //caffee.Notify += NotifySystem;
            caffee.Notify += (string text) => Console.WriteLine(text);


            Console.WriteLine(caffee.FreeSpots);
            Console.WriteLine(caffee.OccupSpots);

            caffee.NewCustomers(5);
            caffee.NewCustomers(4);
            caffee.NewCustomers(20);

            caffee.CustomersGone(4);

            Console.WriteLine(caffee.FreeSpots);
            Console.WriteLine(caffee.OccupSpots);

        }
    }
}
