namespace MeuExercicio.Entities
{
    public class FundoInvestimento
    {
        public FundoInvestimento(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        
        
    }
}