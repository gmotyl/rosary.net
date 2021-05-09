using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrareProMe.Migrations
{
    public partial class guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intentions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intentions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rosaries",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IntentionId = table.Column<byte[]>(type: "varbinary(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rosaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rosaries_Intentions_IntentionId",
                        column: x => x.IntentionId,
                        principalTable: "Intentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rosaries_IntentionId",
                table: "Rosaries",
                column: "IntentionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rosaries");

            migrationBuilder.DropTable(
                name: "Intentions");
        }
    }
}
