using Microsoft.EntityFrameworkCore.Migrations;

namespace Bleems.Database.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "T_Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ProductPhoto = table.Column<string>(type: "nvarchar(265)", maxLength: 265, nullable: true),
                    FileUrlBase = table.Column<string>(type: "nvarchar(265)", maxLength: 265, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Product_T_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "T_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "T_Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "Flowers" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "T_Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "Gifts" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "T_Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 3, "confectionery" });

            migrationBuilder.CreateIndex(
                name: "IX_T_Product_CategoryId",
                schema: "dbo",
                table: "T_Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "T_Category",
                schema: "dbo");
        }
    }
}
