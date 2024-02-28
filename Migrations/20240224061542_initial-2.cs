using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirst.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapProductOrder_Product_ProductId",
                table: "MapProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_MapProductOrder_UserOrder_UserOrderId",
                table: "MapProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrder_Users_UserId",
                table: "UserOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrder",
                table: "UserOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapProductOrder",
                table: "MapProductOrder");

            migrationBuilder.RenameTable(
                name: "UserOrder",
                newName: "UserOrders");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "MapProductOrder",
                newName: "MapProductOrders");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrder_UserId",
                table: "UserOrders",
                newName: "IX_UserOrders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MapProductOrder_UserOrderId",
                table: "MapProductOrders",
                newName: "IX_MapProductOrders_UserOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MapProductOrder_ProductId",
                table: "MapProductOrders",
                newName: "IX_MapProductOrders_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrders",
                table: "UserOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapProductOrders",
                table: "MapProductOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapProductOrders_Products_ProductId",
                table: "MapProductOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapProductOrders_UserOrders_UserOrderId",
                table: "MapProductOrders",
                column: "UserOrderId",
                principalTable: "UserOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Users_UserId",
                table: "UserOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapProductOrders_Products_ProductId",
                table: "MapProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MapProductOrders_UserOrders_UserOrderId",
                table: "MapProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Users_UserId",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrders",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapProductOrders",
                table: "MapProductOrders");

            migrationBuilder.RenameTable(
                name: "UserOrders",
                newName: "UserOrder");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "MapProductOrders",
                newName: "MapProductOrder");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrder",
                newName: "IX_UserOrder_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MapProductOrders_UserOrderId",
                table: "MapProductOrder",
                newName: "IX_MapProductOrder_UserOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MapProductOrders_ProductId",
                table: "MapProductOrder",
                newName: "IX_MapProductOrder_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrder",
                table: "UserOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapProductOrder",
                table: "MapProductOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapProductOrder_Product_ProductId",
                table: "MapProductOrder",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapProductOrder_UserOrder_UserOrderId",
                table: "MapProductOrder",
                column: "UserOrderId",
                principalTable: "UserOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrder_Users_UserId",
                table: "UserOrder",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
