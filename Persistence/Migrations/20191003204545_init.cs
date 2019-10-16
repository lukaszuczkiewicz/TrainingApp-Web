using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmailAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.Id);
                });

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
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_MyProperty_EmailId",
                        column: x => x.EmailId,
                        principalTable: "MyProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Runners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailId = table.Column<Guid>(nullable: true),
                    CoachId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runners_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Runners_MyProperty_EmailId",
                        column: x => x.EmailId,
                        principalTable: "MyProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CoachId = table.Column<Guid>(nullable: true),
                    DateToDo = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    TraningDetailsId = table.Column<Guid>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    RunnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traings_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Traings_Runners_RunnerId",
                        column: x => x.RunnerId,
                        principalTable: "Runners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Traings_TraningDetails_TraningDetailsId",
                        column: x => x.TraningDetailsId,
                        principalTable: "TraningDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_EmailId",
                table: "Coaches",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Runners_CoachId",
                table: "Runners",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Runners_EmailId",
                table: "Runners",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Traings_CoachId",
                table: "Traings",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Traings_RunnerId",
                table: "Traings",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Traings_TraningDetailsId",
                table: "Traings",
                column: "TraningDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Traings");

            migrationBuilder.DropTable(
                name: "Runners");

            migrationBuilder.DropTable(
                name: "TraningDetails");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "MyProperty");
        }
    }
}
