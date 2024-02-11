using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class AddItemStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemStatus",
                table: "Suppliers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemStatus",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemStatus",
                table: "Categories",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemStatus",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ItemStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ItemStatus",
                table: "Categories");
        }
    }
}
