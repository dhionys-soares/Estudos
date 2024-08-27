using Dima.Api.Models;
using Dima.core.Models;
using Dima.core.Models.Reports;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dima.Api.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<User, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long> >(options)
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<IncomesByCategory> IncomesByCategories { get; set; } = null!;
        public DbSet<ExpensesByCategory> ExpensesByCategories { get; set; } = null!;
        public DbSet<IncomesAndExpenses> IncomesAndExpenses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<IncomesByCategory>().HasNoKey().ToView("vwGetIncomesByCategory");
            modelBuilder.Entity<ExpensesByCategory>().HasNoKey().ToView("vwGetExpensesByCategory");
            modelBuilder.Entity<IncomesAndExpenses>().HasNoKey().ToView("vwGetIncomesAndExpenses");
        }


    }
}
