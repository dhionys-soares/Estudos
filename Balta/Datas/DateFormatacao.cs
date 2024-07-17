public class DateFormatacao
{
    public static void DateFormat()
    {
        Console.Clear();

        var hoje = DateTime.Now;
        Console.WriteLine(hoje);

        Console.WriteLine("-----------------------------");

        // para formatar uma data
        var formatada = string.Format("{0:dd-MM-yyyy hh:mm:ss}", hoje);
        Console.WriteLine(formatada);

        Console.WriteLine("-----------------------------");
        var formatada1 = string.Format("{0:t}", hoje); // tempo resumido
        var formatada2 = string.Format("{0:T}", hoje); // tempo completo
        var formatada3 = string.Format("{0:d}", hoje); // data resumida
        var formatada4 = string.Format("{0:D}", hoje); // data completa
        var formatada5 = string.Format("{0:f}", hoje); // junção de tempo e data

        var formatada6 = string.Format("{0:r}", hoje); // padrão que muitos sistemas usam
        var formatada7 = string.Format("{0:s}", hoje); // padrão sortable
        var formatada8 = string.Format("{0:u}", hoje); // padrão universal

        Console.WriteLine(formatada1);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada2);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada3);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada4);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada5);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada6);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada7);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(formatada8);

        Console.ReadLine();
        Menu.Show();
    }
}