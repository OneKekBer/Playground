using Playground.pg.inter.amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum OrderType
{
    Food = 0,
    Mail = 1,
    BigPackage = 2,
    SmallPackage = 3,
}

public interface IOrderItem
{
    string name { get; }

    int price { get; }

    OrderType type { get; }
}

public interface IOrder
{
    IOrderItem[] order { get; }

    public int totalCost
    {
        get
        {
            int sum = 0;
            foreach (var item in order)
            {
                sum += item.price;
            }
            return sum;
        }
    }
    string ID { get; }
}

namespace Playground.pg.inter.amazon
{
    public class Order : IOrder
    {
        public Order(IOrderItem[] order, string ID)
        {
            this.order = order;
            this.ID = ID;
        }

        public bool isOrderCompleted = false;

        public IOrderItem[] order { get; }

        public string ID { get; }
    }

    public class OrderItem : IOrderItem
    {
        public OrderItem(string name, int price, OrderType type)
        {
            this.name = name;
            this.price = price;
            this.type = type;
        }

        public string name { get; }

        public int price { get; }

        public OrderType type { get; }
    }

    public class AmazonHandler<T> where T : IOrder
    {
        public delegate void NotifyHanlder(string text);

        public event NotifyHanlder? notify;

        public List<T> orderList = new List<T>();

        public List<T> completedOrderList = new List<T>();


        public void PrintAllOrders()
        {
            int i = 1;
            foreach (var order in orderList)
            {
                Console.WriteLine($"{i++}. ID:{order.ID}  Total cost:{order.totalCost}");
            }
        }

        public void AcceptOrder(T order)
        {
            orderList.Add(order);

            foreach (var item in order.order)
            {
                Console.WriteLine(item);
            }

            notify.Invoke("Новый заказ с amazon!!");
        }

        public void CompleteOrder(T order)
        {
            
            completedOrderList.Add(order);
            notify.Invoke($"Вы закрыли заказ с amazon id: {order.ID}");
        }
    }

    internal interface Program
    {
        public static void NotifyAction(string text)
        {
            Console.WriteLine(text);
        }

        public static void Start()
        {
            AmazonHandler<Order> amazonHandler = new AmazonHandler<Order>();
            amazonHandler.notify += NotifyAction;

            amazonHandler.AcceptOrder(new Order(new OrderItem[] //тут хз как сделать эту строку более читаемой 
            { 
                new OrderItem("flaga", 500, OrderType.SmallPackage),
                new OrderItem("flaga", 500, OrderType.SmallPackage) 
            }, "aa"));

            amazonHandler.PrintAllOrders();

            Console.WriteLine("tt");
        }
    }
}
