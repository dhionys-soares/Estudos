using Microsoft.EntityFrameworkCore;
using WebApp_MVC_Petshop.Data.Mappings;
using WebApp_MVC_Petshop.Models;

namespace WebApp_MVC_Petshop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Pet> Pets { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=WebApp_MVC_Petshop;User ID=sa;Password=Synoihd10@;Trusted_Connection=False; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PetMap());
        }


    }
}
