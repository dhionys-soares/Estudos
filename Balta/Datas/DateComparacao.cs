public class DateComparacao
{
    public static void ComparacaoDate()
    {
        Console.Clear();
        
        var data = DateTime.Now;

        // não vai ser igual pq existem milésimos de segundos de diferença
        if (data == DateTime.Now)
        {
            Console.WriteLine("É igual");
        }
        else
        {
            Console.WriteLine("NÃO é igual");
        }
        // é necessário atentar-se aos tipos de datas
        if (data.Date == DateTime.Now.Date)
        {
            Console.WriteLine("É igual");
        }
        else
        {
            Console.WriteLine("NÃO é igual");
        }
        Console.ReadLine();
        Menu.Show();
    }
}