using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Fluent.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // tabela
            builder.ToTable("Post");

            // chave primária
            builder.HasKey(x => x.Id);
            // identity
            builder.Property(x => x.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();
            // propriedade
            builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnType("SMALLDATETIME")
            .HasColumnName("LastUpdateDate")
            .HasDefaultValueSql("GETDATE()"); // para obter a data através do banco
            // .HasDefaultValue(DateTime.Now.ToUniversalTime()); // para obter a data através do C#


            builder.Property(x => x.Title)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Title")
            .HasMaxLength(80);

            // índice
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
            .IsUnique();

            // relacionamentos um para muitos
            builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Author")
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Category")
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            // relacionamento muitos para muitos
            builder.HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            
            .UsingEntity<Dictionary<string, object>>("PostTag",
            post => post.HasOne<Tag>()
            .WithMany()
            .HasForeignKey("PostId")
            .HasConstraintName("FK_PostTag_PostId")
            .OnDelete(DeleteBehavior.Cascade),

            tag => tag.HasOne<Post>()
            .WithMany()
            .HasForeignKey("TagId")
            .HasConstraintName("FK_PostTag_TagId")
            .OnDelete(DeleteBehavior.Cascade));
        }
    }
}