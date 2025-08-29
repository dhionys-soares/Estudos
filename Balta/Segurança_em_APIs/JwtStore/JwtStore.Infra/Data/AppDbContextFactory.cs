using JwtStore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

//namespace JwtStore.Infra.Data;

    //public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
        //public AppDbContext CreateDbContext(string[] args)
        //{
            //var configuration = new ConfigurationBuilder()
                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../JwtStore.Api"))
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.Build();

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("JwtStore.Api"));
            
            //return new AppDbContext(optionsBuilder.Options);
        //}
    //}
