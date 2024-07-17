
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Fluent.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // tabela
            builder.ToTable("User");

            // chave primária
            builder.HasKey(x => x.Id);

            // identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.Bio)
                .IsRequired(false);
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);
            
            builder.Property(x => x.Image)
                .IsRequired(false);
            
            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255); ;
            
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // índice
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
            .IsUnique();

            // relacionamento muitos para muitos
            builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)

            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
            role => role
            .HasOne<Role>()
            .WithMany()
            .HasForeignKey("RoleId")
            .HasConstraintName("FK_UserRole_RoleId")
            .OnDelete(DeleteBehavior.Cascade),

            user => user
            .HasOne<User>()
            .WithMany()
            .HasForeignKey("UserId")
            .HasConstraintName("FK_UserRole_UserId")
            .OnDelete(DeleteBehavior.Cascade));
        }
    }
}