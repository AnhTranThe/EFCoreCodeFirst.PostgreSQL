using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirst.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class initial_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapProductOrders");

            migrationBuilder.CreateTable(
                name: "UserOrderProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    UserOrderId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrderProducts_UserOrders_UserOrderId",
                        column: x => x.UserOrderId,
                        principalTable: "UserOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderProducts_UserOrderId",
                table: "UserOrderProducts",
                column: "UserOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOrderProducts");

            migrationBuilder.CreateTable(
                name: "MapProductOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    UserOrderId = table.Column<string>(type: "text", nullable: false),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapProductOrders_UserOrders_UserOrderId",
                        column: x => x.UserOrderId,
                        principalTable: "UserOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapProductOrders_ProductId",
                table: "MapProductOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MapProductOrders_UserOrderId",
                table: "MapProductOrders",
                column: "UserOrderId");
        }
    }
}
