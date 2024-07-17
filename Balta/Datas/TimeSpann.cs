public class TimeSpann
{
    public static void Timespaan()
    {

        Console.Clear();

        var timeSpan = new TimeSpan();
        Console.WriteLine(timeSpan);
        Console.WriteLine("===============================");
        var timeSpanNanoSegundos = new TimeSpan(1);
        Console.WriteLine(timeSpanNanoSegundos);
        Console.WriteLine("===============================");
        var timesSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
        Console.WriteLine(timesSpanHoraMinutoSegundo);
        Console.WriteLine("===============================");
        var timesSpanDiaHoraMinutoSegundo = new TimeSpan(15, 12, 55, 8, 98);
        Console.WriteLine(timesSpanDiaHoraMinutoSegundo);
        Console.WriteLine("===============================");
        Console.WriteLine(timesSpanDiaHoraMinutoSegundo - timesSpanHoraMinutoSegundo);
        Console.WriteLine("===============================");
        Console.WriteLine(timesSpanDiaHoraMinutoSegundo.Days);
        Console.WriteLine("===============================");
        Console.WriteLine(timesSpanHoraMinutoSegundo.Add(new TimeSpan(10, 0, 0)));

        Console.ReadLine();
        
        DiasDoMes();
        Console.ReadLine();
        
        
        Console.WriteLine(IsWeekendDay(DateTime.Now.DayOfWeek));

        Console.ReadLine();
        Menu.Show();
    }

    public static void DiasDoMes()
    {
        Console.WriteLine(DateTime.DaysInMonth(2020, 2));
    }

    public static bool IsWeekendDay(DayOfWeek today)
    {
        return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
    }
}