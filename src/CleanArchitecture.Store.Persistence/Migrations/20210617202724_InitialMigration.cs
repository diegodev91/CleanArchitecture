using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Store.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EndOfContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EndOfContract", "LastModifiedBy", "LastModifiedDate", "Name", "Provider" },
                values: new object[] { 1, "AdminUserID", new DateTime(2021, 6, 17, 15, 27, 23, 698, DateTimeKind.Local).AddTicks(1970), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "VideoGames", "Amazon" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EndOfContract", "LastModifiedBy", "LastModifiedDate", "Name", "Provider" },
                values: new object[] { 2, "AdminUserID", new DateTime(2021, 6, 17, 15, 27, 23, 714, DateTimeKind.Local).AddTicks(8510), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "TV", "Local" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EndOfContract", "LastModifiedBy", "LastModifiedDate", "Name", "Provider" },
                values: new object[] { 3, "AdminUserID", new DateTime(2021, 6, 17, 15, 27, 23, 714, DateTimeKind.Local).AddTicks(8640), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Computers", "Local" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Currency", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 4, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "Play Station 5", 3500.00m, 50 },
                    { 5, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "X Box", 2500.00m, 50 },
                    { 6, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "Nintendo Switch", 2200.00m, 200 },
                    { 7, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "Samsumg TV 65'", 5600.00m, 150 },
                    { 8, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "LG OLED TV 75'", 15000.00m, 50 },
                    { 9, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "Panasonic", 1500.00m, 200 },
                    { 10, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "MacBook Pro 13'", 10000.00m, 10 },
                    { 11, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "Alienware 15'", 5700.00m, 40 },
                    { 12, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S/.", null, null, null, null, "Asus Pro 2tb 15'", 2200.00m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
