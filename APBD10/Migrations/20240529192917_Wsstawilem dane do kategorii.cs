using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD10.Migrations
{
    /// <inheritdoc />
    public partial class Wsstawilemdanedokategorii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catgories",
                columns: new[] { "PK_Category", "name" },
                values: new object[,]
                {
                    { 1, "Grzechotka" },
                    { 2, "Flet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Catgories",
                keyColumn: "PK_Category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catgories",
                keyColumn: "PK_Category",
                keyValue: 2);
        }
    }
}
