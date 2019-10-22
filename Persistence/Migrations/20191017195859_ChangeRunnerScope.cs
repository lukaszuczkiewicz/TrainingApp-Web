using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeRunnerScope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Runners");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Runners");

            migrationBuilder.DropColumn(
                name: "PreSharedKey",
                table: "Runners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Runners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Runners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreSharedKey",
                table: "Runners",
                nullable: true);
        }
    }
}
