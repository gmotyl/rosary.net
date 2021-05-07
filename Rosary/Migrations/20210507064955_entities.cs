using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rosary.Migrations
{
    public partial class entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "OwnerId",
                table: "Intentions",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intentions_OwnerId",
                table: "Intentions",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intentions_User_OwnerId",
                table: "Intentions",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intentions_User_OwnerId",
                table: "Intentions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Intentions_OwnerId",
                table: "Intentions");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Intentions");
        }
    }
}
