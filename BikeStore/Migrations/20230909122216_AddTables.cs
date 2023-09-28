using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeStore.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category_name",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Zip_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Zip_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Store_id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Store_id = table.Column<int>(type: "int", nullable: false),
                    Manager_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Staff_id);
                    table.ForeignKey(
                        name: "FK_Staffs_Stores_Store_id",
                        column: x => x.Store_id,
                        principalTable: "Stores",
                        principalColumn: "Store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_id = table.Column<int>(type: "int", nullable: true),
                    Order_status = table.Column<byte>(type: "tinyint", nullable: false),
                    Order_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Required_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipped_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store_id = table.Column<int>(type: "int", nullable: false),
                    Staff_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "Customers",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK_Orders_Staffs_Staff_id",
                        column: x => x.Staff_id,
                        principalTable: "Staffs",
                        principalColumn: "Staff_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_Store_id",
                        column: x => x.Store_id,
                        principalTable: "Stores",
                        principalColumn: "Store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Model_year = table.Column<short>(type: "smallint", nullable: false),
                    List_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Brand_id = table.Column<int>(type: "int", nullable: false),
                    Category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "Brands",
                        principalColumn: "Brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Categories",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_items",
                columns: table => new
                {
                    Item_id = table.Column<int>(type: "int", nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    List_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Descount = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Brand_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_items", x => new { x.Order_id, x.Item_id });
                    table.ForeignKey(
                        name: "FK_Order_items_Brands_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "Brands",
                        principalColumn: "Brand_id");
                    table.ForeignKey(
                        name: "FK_Order_items_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_items_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Product_id",
                table: "Brands",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_items_Brand_id",
                table: "Order_items",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_items_Product_id",
                table: "Order_items",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customer_id",
                table: "Orders",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Staff_id",
                table: "Orders",
                column: "Staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Store_id",
                table: "Orders",
                column: "Store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Brand_id",
                table: "Products",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_id",
                table: "Products",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Email",
                table: "Staffs",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Store_id",
                table: "Staffs",
                column: "Store_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Products_Product_id",
                table: "Brands",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Products_Product_id",
                table: "Brands");

            migrationBuilder.DropTable(
                name: "Order_items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.AlterColumn<string>(
                name: "Category_name",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
