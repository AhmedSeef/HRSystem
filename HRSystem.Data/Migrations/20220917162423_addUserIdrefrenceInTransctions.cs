using Microsoft.EntityFrameworkCore.Migrations;

namespace HRSystem.Data.Migrations
{
    public partial class addUserIdrefrenceInTransctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginUserId",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_LoginUserId",
                table: "Transaction",
                column: "LoginUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Employee_LoginUserId",
                table: "Transaction",
                column: "LoginUserId",
                principalTable: "Employee",
                principalColumn: "Employee_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Employee_LoginUserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_LoginUserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "LoginUserId",
                table: "Transaction");
        }
    }
}
