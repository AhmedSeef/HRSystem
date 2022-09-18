using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRSystem.Data.Migrations
{
    public partial class addTransctionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLogin = table.Column<DateTime>(nullable: false),
                    DateSignIn = table.Column<DateTime>(nullable: false),
                    DateSignOut = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
