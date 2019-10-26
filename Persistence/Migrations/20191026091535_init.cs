using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "TraningDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraningDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PreSharedKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_Coaches_Login", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Runners",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    RunnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runners", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Runners_Coaches_RunnerId",
                        column: x => x.RunnerId,
                        principalSchema: "Core",
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateToDo = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    TraningDetailsId = table.Column<Guid>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false, defaultValue: false),
                    RunnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Trainings_Runners_RunnerId",
                        column: x => x.RunnerId,
                        principalSchema: "Core",
                        principalTable: "Runners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_TraningDetails_TraningDetailsId",
                        column: x => x.TraningDetailsId,
                        principalTable: "TraningDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Runners_RunnerId",
                schema: "Core",
                table: "Runners",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_RunnerId",
                schema: "Core",
                table: "Trainings",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TraningDetailsId",
                schema: "Core",
                table: "Trainings",
                column: "TraningDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainings",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Runners",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TraningDetails");

            migrationBuilder.DropTable(
                name: "Coaches",
                schema: "Core");
        }
    }
}
