using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RenameCoachIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runners_Coaches_RunnerId",
                schema: "Core",
                table: "Runners");

            migrationBuilder.RenameColumn(
                name: "RunnerId",
                schema: "Core",
                table: "Runners",
                newName: "CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_Runners_RunnerId",
                schema: "Core",
                table: "Runners",
                newName: "IX_Runners_CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Runners_Coaches_CoachId",
                schema: "Core",
                table: "Runners",
                column: "CoachId",
                principalSchema: "Core",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runners_Coaches_CoachId",
                schema: "Core",
                table: "Runners");

            migrationBuilder.RenameColumn(
                name: "CoachId",
                schema: "Core",
                table: "Runners",
                newName: "RunnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Runners_CoachId",
                schema: "Core",
                table: "Runners",
                newName: "IX_Runners_RunnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Runners_Coaches_RunnerId",
                schema: "Core",
                table: "Runners",
                column: "RunnerId",
                principalSchema: "Core",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
