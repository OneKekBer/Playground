using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Project.test
{

    class Monitor
    {
        public delegate void MonitorChange(int currentPrice); // создаем делегат который принимает число и ничего не возращает

        public MonitorChange MonitorPriceHandler { get; set; } // свойство которое с типом делегата,
                                                               // теперь MonitorPriceHandler это метод который принимает число и ничего не возращает,
                                                               // можно сказать что это пустая оболочка которая ничего не делает

        public void Start()
        {
            while (true)
            {
                int price = new Random().Next(100);

                MonitorPriceHandler(price);//здесь как раз в этот метод мы вызываем и передаем в аргумент текующую цену
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }

        // podsumowanie
        // то что написно здесь любой метод может принять и как то обрабатывать то что мы передаем
        // можно сказать что мы управляем чем то абстрактным( я имею в виду метод MonitorPriceHandler)
        // мы не знаем что он делает но точно знаем что мы в него передаем

    }

    public class PM
    {
        public static void Test()
        {
            Monitor monitor = new Monitor();

            monitor.MonitorPriceHandler = ShowPriceInDollars; // теперь как раз из пустой оболочки мы создаем метод который будет что то выводить 
            monitor.MonitorPriceHandler += ShowPriceInEuro;
            monitor.Start();


            Console.WriteLine("Hello World");
        }
        public static void ShowPriceInDollars(int currentPrice)
        {
            Console.Write($"current price in dollar: {currentPrice}$    ");
        }

        public static void ShowPriceInEuro(int currentPrice)
        {
            Console.Write($"current price in euro: {Math.Round(currentPrice * 1.1, 10)} euro ");
        }
    }

}






