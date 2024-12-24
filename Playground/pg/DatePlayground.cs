namespace Playground.pg.DatePlayground;

public class Program 
{
    public static void Start()
    {
        var date = new DateOnly(2020, 1, 1);

        Console.WriteLine(date);
        
        var expirationDate = date.AddDays(7);
        
        var today = DateOnly.FromDateTime(DateTime.Today);
        Console.WriteLine(expirationDate);

        Console.WriteLine(today);
    }
}