using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp_MVC_Petshop.Models;

namespace WebApp_MVC_Petshop.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x=>x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x=>x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength (30);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.HasMany(x => x.Pets)
                .WithOne(x => x.Cliente)
                .HasConstraintName("FK_Cliente_Pet")
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
