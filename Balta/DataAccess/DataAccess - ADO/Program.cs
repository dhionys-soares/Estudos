using Microsoft.Data.SqlClient;

const string connectionstring = "Server=localhost,1433;Database=balta;User ID=sa;Password=Synoihd10@;Trusted_Connection=False; TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionstring))
{
    System.Console.WriteLine("Conectado");
    connection.Open();
    using (var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT[Id], [Title] FROM [Category]";

        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            System.Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
        }
    }
}