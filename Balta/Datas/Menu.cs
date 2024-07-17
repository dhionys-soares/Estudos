public class Menu
{
    public static void Show()
    {
        Console.Clear();

        Console.WriteLine("selecione sua opção:");
        Console.WriteLine
        (@"
1 - Tipos de datas
2 - Parametros de datas
3 - Formatação de datas
4 - Adicionando datas
5 - Comparar datas
6 - CultureInfo
7 - TimeSpan
0 - Exit");

        var option = short.Parse(Console.ReadLine());
        switch (option)
        {
            case 1: TipoDatas.TipoDatass(); break;
            case 2: DateTimeParametros.DateParametros(); break;
            case 3: DateFormatacao.DateFormat(); break;
            case 4: Adddates.AddDates(); break;
            case 5: DateComparacao.ComparacaoDate(); break;
            case 6: Cultura.Culturas(); break;
            case 7: TimeSpann.Timespaan(); break;
            case 0: Environment.Exit(0); break;

            default: Show(); break;
        }
    }
}