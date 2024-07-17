using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp_MVC_Petshop.Models;

namespace WebApp_MVC_Petshop.Data.Mappings
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x=>x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
        }
    }
}
