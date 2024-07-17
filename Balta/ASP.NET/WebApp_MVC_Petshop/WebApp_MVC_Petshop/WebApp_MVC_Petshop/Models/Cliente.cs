namespace WebApp_MVC_Petshop.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Pet> Pets { get; set; } = new();        
    }
}
