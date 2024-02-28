using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirst.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Product", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Users", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_UserDetails", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "UserOrder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_UserOrder", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_UserOrder_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "MapProductOrder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    UserOrderId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "text", nullable: false),
                    UpdateBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_MapProductOrder", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_MapProductOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_MapProductOrder_UserOrder_UserOrderId",
                        column: x => x.UserOrderId,
                        principalTable: "UserOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_MapProductOrder_ProductId",
                table: "MapProductOrder",
                column: "ProductId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_MapProductOrder_UserOrderId",
                table: "MapProductOrder",
                column: "UserOrderId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_UserOrder_UserId",
                table: "UserOrder",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "MapProductOrder");

            _ = migrationBuilder.DropTable(
                name: "UserDetails");

            _ = migrationBuilder.DropTable(
                name: "Product");

            _ = migrationBuilder.DropTable(
                name: "UserOrder");

            _ = migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
