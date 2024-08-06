using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity
{
    public class IdentityUserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("IdentityUser");
            builder.HasKey(t => t.Id);

            builder.HasIndex(inu => inu.NormalizedUserName).IsUnique();
            builder.HasIndex(ine => ine.NormalizedEmail).IsUnique();

            builder.Property(e => e.Email).HasMaxLength(180);
            builder.Property(ne => ne.NormalizedEmail).HasMaxLength(180);

            builder.Property(u => u.UserName).HasMaxLength(180);
            builder.Property(nu => nu.NormalizedUserName).HasMaxLength(180);

            builder.Property(p => p.PhoneNumber).HasMaxLength(20);

            builder.Property(c => c.ConcurrencyStamp).IsConcurrencyToken();

            builder.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(f => f.UserId).IsRequired();
            builder.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(f => f.UserId).IsRequired();
            builder.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(f => f.UserId).IsRequired();
            builder.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(f => f.UserId).IsRequired();
        }
    }
}
