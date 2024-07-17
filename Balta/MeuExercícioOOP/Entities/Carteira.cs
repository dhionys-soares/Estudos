namespace MeuExercicio.Entities
{
    public class Carteira
    {
        public Carteira(string nome, Rpps rpps, List<FundoInvestimento> fundoInvestimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Rpps = rpps;
            FundosInvestimentos = new List<FundoInvestimento>(fundoInvestimento);
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Rpps Rpps { get; set; }
        public List<FundoInvestimento> FundosInvestimentos { get; set; }
    }
}