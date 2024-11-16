using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookKart.Core.Infrastructure.Migrations
{
    public partial class Alter_Table_Cart_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Cart_UserId",
            table: "Cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true);
        }
    }
}
