using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class ModifyItemStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemStatus",
                table: "Suppliers",
                newName: "SupplierStatus");

            migrationBuilder.RenameColumn(
                name: "ItemStatus",
                table: "Products",
                newName: "ProductStatus");

            migrationBuilder.RenameColumn(
                name: "ItemStatus",
                table: "Categories",
                newName: "CategoryStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierStatus",
                table: "Suppliers",
                newName: "ItemStatus");

            migrationBuilder.RenameColumn(
                name: "ProductStatus",
                table: "Products",
                newName: "ItemStatus");

            migrationBuilder.RenameColumn(
                name: "CategoryStatus",
                table: "Categories",
                newName: "ItemStatus");
        }
    }
}
