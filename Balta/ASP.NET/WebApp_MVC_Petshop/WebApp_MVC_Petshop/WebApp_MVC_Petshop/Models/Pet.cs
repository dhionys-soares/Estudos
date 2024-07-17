namespace WebApp_MVC_Petshop.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cliente Cliente { get; set; } = null;
    }
}
