using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Fluent.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // tabela
            builder.ToTable("Category");
            // chave primária
            builder.HasKey(x => x.Id);
           
            // identity
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
            .UseIdentityColumn();

            // propriedades
        builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(80);

        builder.Property(x => x.Slug)
        .IsRequired()
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

        //índices
        builder.HasIndex(x => x.Slug, "IX_Category_Slug")
        .IsUnique();
        
        }
    }
}