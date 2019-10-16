using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreSharedCode",
                table: "Runners",
                newName: "PreSharedKey");

            migrationBuilder.AddColumn<string>(
                name: "PreSharedKey",
                table: "Coaches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreSharedKey",
                table: "Coaches");

            migrationBuilder.RenameColumn(
                name: "PreSharedKey",
                table: "Runners",
                newName: "PreSharedCode");
        }
    }
}
