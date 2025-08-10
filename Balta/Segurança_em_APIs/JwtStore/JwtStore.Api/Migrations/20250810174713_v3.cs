using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email_Verification_ExpiresAt",
                table: "User",
                newName: "EmailVerificationExpiresAt");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "EmailVerificationExpiresAt",
                table: "User",
                newName: "Email_Verification_ExpiresAt");
        }
    }
}
