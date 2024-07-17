namespace MeuExercicio.Entities
{
    public class Rpps
    {
        public Rpps(string nome, string cNPJ, string gestor)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CNPJ = cNPJ;
            Gestor = gestor;            
            Carteiras = new List<Carteira>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Gestor { get; set; }        
        public List<Carteira> Carteiras { get; set; }
    }
}