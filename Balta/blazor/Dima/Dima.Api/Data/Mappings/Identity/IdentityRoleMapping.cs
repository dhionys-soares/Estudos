using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity
{
    public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<long>> builder)
        {
            builder.ToTable("IdentityRole");
            builder.HasKey(r => r.Id);

            builder.HasIndex(i => i.NormalizedName).IsUnique();

            builder.Property(cs => cs.ConcurrencyStamp).IsConcurrencyToken();
            
            builder.Property(n => n.Name).HasMaxLength(256);
            builder.Property(nn => nn.NormalizedName).HasMaxLength(256);
        }
    }
}
