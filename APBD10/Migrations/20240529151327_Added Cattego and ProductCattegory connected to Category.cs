using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD10.Migrations
{
    /// <inheritdoc />
    public partial class AddedCattegoandProductCattegoryconnectedtoCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Shopping_Carts",
                newName: "ShoppingCartAmount");

            migrationBuilder.CreateTable(
                name: "Catgories",
                columns: table => new
                {
                    PK_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catgories", x => x.PK_Category);
                });

            migrationBuilder.CreateTable(
                name: "Product_Categories",
                columns: table => new
                {
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    FK_category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Categories", x => new { x.FK_product, x.FK_category });
                    table.ForeignKey(
                        name: "FK_Product_Categories_Catgories_FK_category",
                        column: x => x.FK_category,
                        principalTable: "Catgories",
                        principalColumn: "PK_Category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Categories_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Categories_FK_category",
                table: "Product_Categories",
                column: "FK_category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Categories");

            migrationBuilder.DropTable(
                name: "Catgories");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartAmount",
                table: "Shopping_Carts",
                newName: "amount");
        }
    }
}
