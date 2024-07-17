public class Adddates
{
    public static void AddDates()
    {
        // Adicionando dias, meses e anos
        Console.Clear();
        
        var today = DateTime.Now;
        System.Console.WriteLine(today);
        Console.WriteLine("-----------------------------");
        System.Console.WriteLine(today.AddDays(1));
        Console.WriteLine("-----------------------------");
        System.Console.WriteLine(today.AddMonths(1));
        Console.WriteLine("-----------------------------");
        System.Console.WriteLine(today.AddYears(1));

        Console.ReadLine();
        Menu.Show();
    }
}