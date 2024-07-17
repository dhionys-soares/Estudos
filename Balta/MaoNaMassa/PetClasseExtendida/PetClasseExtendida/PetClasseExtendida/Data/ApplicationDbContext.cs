using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClasseExtendida.Models;

namespace PetClasseExtendida.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
