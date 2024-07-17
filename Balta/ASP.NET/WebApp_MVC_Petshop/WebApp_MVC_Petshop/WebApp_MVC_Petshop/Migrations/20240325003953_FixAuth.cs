using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_MVC_Petshop.Migrations
{
    /// <inheritdoc />
    public partial class FixAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Cliente",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Cliente",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50);
        }
    }
}
