namespace Playground.projects.MQ.Main;

// CONTEXT
public class Order
{
    public Order(int number)
    {
        Number = number;
    }
    
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public int Number { get; init; }
}

public class Database
{
    private readonly List<Order> _orders = new();

    public async Task Add(Order order)
    {
        await Task.Delay(500);
        _orders.Add(order);
        Console.WriteLine($"Database added order with number : {order.Number}");
    }
}

public class AnotherService
{
    public async Task DoSmth()
    {
        await Task.Delay(1000);
        Console.WriteLine("AnotherService did smth");
    }
}

public class OrderHandlerService
{
    private readonly Database _database;

    public OrderHandlerService(Database database)
    {
        _database = database;
    }

    public async Task Handle(Order order)
    {
        await Task.Delay(1000); 
        Console.WriteLine("OrderHandlerService handled order");
        await _database.Add(order);
    }
}

// MAIN PART
public class Program
{
    public static async Task Start()
    {
        var mq = new MessageQueue<Order>();
        var db = new Database();
        var service = new OrderHandlerService(db);
        var mqWorker = new QueueWorker(mq, service);
        var anotherService = new AnotherService();

        var orders = new[]
        {
            new Order(1),
            new Order(2),
            new Order(3),
            new Order(4),
        };

        foreach (var order in orders)
        {
            mq.Add(order);
        }

        var workerTask = mqWorker.DoWork();

       
        await anotherService.DoSmth();
        await anotherService.DoSmth();

        mq.Add(new Order(1001));
        await anotherService.DoSmth();

        await anotherService.DoSmth();
        await anotherService.DoSmth();

        mq.Add(new Order(1000));
        await anotherService.DoSmth();

        
        await workerTask;
    }
}

public class QueueWorker
{
    private readonly MessageQueue<Order> _queue;
    private readonly OrderHandlerService _orderHandlerService;

    public QueueWorker(MessageQueue<Order> queue, OrderHandlerService orderHandlerService)
    {
        _queue = queue;
        _orderHandlerService = orderHandlerService;
    }

    public async Task DoWork()
    {
        while (_queue.HasItems)
        {
            var order = _queue.Get();
            await _orderHandlerService.Handle(order);
        }
    }
}

public class MessageQueue<T> where T : class
{
    private readonly Queue<T> _queue = new();

    public void Add(T item)
    {
        _queue.Enqueue(item);
    }

    public T Get()
    {
        return _queue.Dequeue();
    }

    public bool HasItems => _queue.Count > 0;
}
