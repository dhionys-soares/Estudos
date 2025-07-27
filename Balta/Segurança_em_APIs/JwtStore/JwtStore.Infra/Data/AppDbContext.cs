using JwtStore.Core.Contexts.AccountContext.Entities;
using JwtStore.Infra.Contexts.AccountContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    DbSet<User>  Users { get; set; } =  null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}