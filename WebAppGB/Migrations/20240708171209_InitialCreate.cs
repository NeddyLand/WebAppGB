using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppGB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    pg_name = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_group_pk", x => x.pg_name);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("storage_pk", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    prd_name = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductGroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_pk", x => x.prd_name);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupID",
                        column: x => x.ProductGroupID,
                        principalTable: "ProductGroups",
                        principalColumn: "pg_name");
                });

            migrationBuilder.CreateTable(
                name: "ProductStorage",
                columns: table => new
                {
                    ProductsID = table.Column<int>(type: "int", nullable: false),
                    StoragesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStorage", x => new { x.ProductsID, x.StoragesID });
                    table.ForeignKey(
                        name: "FK_ProductStorage_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "prd_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStorage_Storages_StoragesID",
                        column: x => x.StoragesID,
                        principalTable: "Storages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupID",
                table: "Products",
                column: "ProductGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStorage_StoragesID",
                table: "ProductStorage",
                column: "StoragesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStorage");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
