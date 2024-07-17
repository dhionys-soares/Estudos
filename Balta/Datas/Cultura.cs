using System.Globalization;

public class Cultura
{
    public static void Culturas()
    {
        Console.Clear();

        var pt = new CultureInfo("pt-PT"); // portugues de portugal
        var br = new CultureInfo("pt-BR"); // portugues do brasil
        var eng = new CultureInfo("en-UK"); // inglês britânico
        var en = new CultureInfo("en-US"); // inglês americano
        var de = new CultureInfo("de-DE"); // Dinamarca
        var atual = CultureInfo.CurrentCulture; // aplica a configuração de data do computador
        var utc = DateTime.UtcNow; // informa a data baseado num padrão universal
        var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
        var hourAustralia = TimeZoneInfo.ConvertTimeFromUtc(utc, timezoneAustralia);

        Console.WriteLine(DateTime.Now.ToString("D", pt));
        Console.WriteLine("----------------------------");
        Console.WriteLine(DateTime.Now.ToString("D", br));
        Console.WriteLine("----------------------------");
        Console.WriteLine(DateTime.Now.ToString("D", eng));
        Console.WriteLine("----------------------------");
        Console.WriteLine(DateTime.Now.ToString("D", en));
        Console.WriteLine("----------------------------");
        Console.WriteLine(DateTime.Now.ToString("D", de));
        Console.WriteLine(DateTime.Now.ToString("D", atual));
        Console.WriteLine("----------------------------");
        Console.WriteLine(utc);
        Console.WriteLine("----------------------------");
        Console.WriteLine(utc.ToLocalTime()); // converte o padrão universal para o padrão local
        Console.WriteLine("----------------------------");
        Console.WriteLine(timezoneAustralia);
        Console.WriteLine("----------------------------");
        Console.WriteLine(hourAustralia);
        Console.WriteLine("----------------------------");

        Console.ReadLine();
        TimezoneList(utc);
    }

    public static void TimezoneList(DateTime utc)
    {
        Console.Clear();
        var timeszones = TimeZoneInfo.GetSystemTimeZones();

        foreach (var item in timeszones)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item);
            Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utc, item));
            Console.WriteLine("----------------------------");
        }
        Console.ReadLine();
            Menu.Show();
    }
}