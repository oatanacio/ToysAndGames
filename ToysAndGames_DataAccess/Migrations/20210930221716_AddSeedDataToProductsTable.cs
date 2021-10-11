using Microsoft.EntityFrameworkCore.Migrations;

namespace ToysAndGames_DataAccess.Migrations
{
    public partial class AddSeedDataToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 1, 99, "Mattel", "Word Game", "Scrabble", 99.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "AgeRestriction", "Company", "Description", "Name", "Price" },
                values: new object[] { 2, 99, "Mattel", "Cards Game", "Uno", 49.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_Id",
                keyValue: 2);
        }
    }
}
