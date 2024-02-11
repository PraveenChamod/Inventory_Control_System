using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryEntityToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaximumStockCount = table.Column<int>(type: "integer", nullable: true),
                    MinimumStockCount = table.Column<int>(type: "integer", nullable: true),
                    AvailableStockCount = table.Column<int>(type: "integer", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDescription = table.Column<int>(type: "integer", nullable: false),
                    UpdateEmployeeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => new { x.ProductId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_Inventories_Employees_UpdateEmployeeId",
                        column: x => x.UpdateEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UpdateEmployeeId",
                table: "Inventories",
                column: "UpdateEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
