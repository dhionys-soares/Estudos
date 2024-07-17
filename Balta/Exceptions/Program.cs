var array = new int[3];

try
{
    /* for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(array[i]);
    } */
    Cadastrar("");
}
catch (IndexOutOfRangeException ex)
{
Console.WriteLine(ex.InnerException);
Console.WriteLine(ex.Message);
Console.WriteLine("Não encontrei o índice na lista.");
}
catch (ArgumentNullException ex)
{
Console.WriteLine(ex.Message + "O texto não pode ser nulo ou vazio2.");
}
catch (Exception ex) // o exception mais genérico fica após os tipos específicos
{
    Console.WriteLine(ex.InnerException);
    Console.WriteLine(ex.Message);
    Console.WriteLine("Ops! Algo deu errado...");
}
finally{
    Console.WriteLine("chegamos ao fim"); // mesmo que o programa quebre nos catchs acima, o finally vai executar de qualquer forma.
}

static void Cadastrar(string texto){
    if (string.IsNullOrEmpty(texto))
    {
        throw new MinhaException(DateTime.Now);
    }
}
public class MinhaException : Exception{ // exception customizada
    public MinhaException(DateTime date)
    {
        QuandoAconteceu = date;
    }

    public DateTime QuandoAconteceu {get; set;}
}