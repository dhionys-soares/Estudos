var pessoaA = new Pessoa(1, "Dhionys");
var pessoaB = new Pessoa(1, "Dhionys");

Console.WriteLine(pessoaA.Equals(pessoaB));

Console.WriteLine("===============================");

static void RealizarPagamento(double valor)
{
Console.WriteLine($"Pago o valor de {valor}");
}

var pagamento = new Pagamento.Pagar(RealizarPagamento);

public class Pessoa : IEquatable<Pessoa>
{
    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;

    }

    public int Id { get; set; }
    public string Nome { get; set; }

    public bool Equals(Pessoa? pessoa)
    {
        return Id == pessoa?.Id;
    }
}
public class PessoaFisica : Pessoa
{
    public PessoaFisica(int id, string nome) : base(id, nome)
    {
    }
}

public class PessoaJuridica : Pessoa
{
    public PessoaJuridica(int id, string nome) : base(id, nome)
    {
    }
}

public class Pagamento
{
    public delegate void Pagar(double valor);
}