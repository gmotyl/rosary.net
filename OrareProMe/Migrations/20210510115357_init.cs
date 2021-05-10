using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrareProMe.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intentions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<byte[]>(type: "varbinary(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intentions_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rosaries",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IntentionId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rosaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rosaries_Intentions_IntentionId",
                        column: x => x.IntentionId,
                        principalTable: "Intentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prayers",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RosaryId = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prayers_Rosaries_RosaryId",
                        column: x => x.RosaryId,
                        principalTable: "Rosaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intentions_OwnerId",
                table: "Intentions",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prayers_RosaryId",
                table: "Prayers",
                column: "RosaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rosaries_IntentionId",
                table: "Rosaries",
                column: "IntentionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prayers");

            migrationBuilder.DropTable(
                name: "Rosaries");

            migrationBuilder.DropTable(
                name: "Intentions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
