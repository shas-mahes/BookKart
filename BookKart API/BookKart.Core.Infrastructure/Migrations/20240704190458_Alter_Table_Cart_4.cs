using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookKart.Core.Infrastructure.Migrations
{
    public partial class Alter_Table_Cart_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cart_BookId",
                table: "Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_BookId_UserId",
                table: "Cart",
                columns: new[] { "BookId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cart_BookId_UserId",
                table: "Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_BookId",
                table: "Cart",
                column: "BookId",
                unique: true);
        }
    }
}
