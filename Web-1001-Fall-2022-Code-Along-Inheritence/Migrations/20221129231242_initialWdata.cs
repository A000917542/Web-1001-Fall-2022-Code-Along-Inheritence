using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Migrations
{
    public partial class initialWdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Email);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_Email",
                        column: x => x.Email,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShoppingCart",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingCartsEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShoppingCart", x => new { x.ProductsId, x.ShoppingCartsEmail });
                    table.ForeignKey(
                        name: "FK_ProductShoppingCart_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShoppingCart_ShoppingCarts_ShoppingCartsEmail",
                        column: x => x.ShoppingCartsEmail,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("09f561b4-def2-4cbc-95ac-1a930aabe6b4"), "", "Test 2", 1.00m },
                    { new Guid("71754de9-3064-4ba7-93be-344345d4a6e1"), "", "Test 1", 2.00m },
                    { new Guid("b77cc9b8-e33d-45a2-91c0-eb397c8549ff"), "", "Test 3", 7.00m },
                    { new Guid("ed7d2a3c-5e3e-4cad-bd43-907dc0d6f767"), "", "Test 4", 3.00m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Address", "Name" },
                values: new object[,]
                {
                    { "example@example.com", "Address 1", "Example 1" },
                    { "example2@example.com", "Address 2", "Example 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCart_ShoppingCartsEmail",
                table: "ProductShoppingCart",
                column: "ShoppingCartsEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShoppingCart");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
