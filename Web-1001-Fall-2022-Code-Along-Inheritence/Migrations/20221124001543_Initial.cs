using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Migrations
{
    public partial class Initial : Migration
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
