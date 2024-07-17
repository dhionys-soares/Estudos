public class DateTimeParametros
{
    public static void DateParametros()
    {
        Console.Clear();

        var dat = new DateTime(2020, 11, 18); // aceita várias sobrecargas, como ano, mês e dia

        // é possível obter dia, mês, ano, minutos, segundos, dia da semana, como abaixo
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dat.Day);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dat);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dat.Month);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dat.Year);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dat.DayOfWeek);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dat.DayOfYear);

        Console.ReadLine();
        Menu.Show();
    }
}