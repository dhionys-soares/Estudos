using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_MVC_Petshop.Migrations
{
    /// <inheritdoc />
    public partial class Authenticacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Cliente",
                type: "NVARCHAR",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Cliente");
        }
    }
}
