public class TipoDatas
{
    public static void TipoDatass()
    {
        Console.Clear();

        var data = new DateTime(); // é um struct, é um value type
        var dataa = DateTime.Now; // para obter data e hora atual

        Console.WriteLine(data);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(dataa);
        Console.WriteLine("-----------------------------");

        Console.ReadLine();
        Menu.Show();
    }
}