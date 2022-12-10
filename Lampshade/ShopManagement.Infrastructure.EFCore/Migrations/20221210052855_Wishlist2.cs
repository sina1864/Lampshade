using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class Wishlist2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_UserId",
                table: "WishlistItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WishlistItems",
                newName: "WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_UserId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems");

            migrationBuilder.RenameColumn(
                name: "WishlistId",
                table: "WishlistItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_WishlistId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_UserId",
                table: "WishlistItems",
                column: "UserId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
