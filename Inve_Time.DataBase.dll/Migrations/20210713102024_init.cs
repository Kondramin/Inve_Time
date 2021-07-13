using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inve_Time.DataBase.dll.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpCategorySearchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpCategorySearchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpCategorySearchers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmountData = table.Column<int>(type: "int", nullable: false),
                    AmountFact = table.Column<int>(type: "int", nullable: false),
                    AmountResult = table.Column<int>(type: "int", nullable: false),
                    Peresort = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateOfInventarisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarisationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateOfInventarisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateOfInventarisations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateOfInventarisationProduct",
                columns: table => new
                {
                    DateOfInventarisationsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateOfInventarisationProduct", x => new { x.DateOfInventarisationsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DateOfInventarisationProduct_DateOfInventarisations_DateOfInventarisationsId",
                        column: x => x.DateOfInventarisationsId,
                        principalTable: "DateOfInventarisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateOfInventarisationProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Внешние аккумуляторы" },
                    { 24, "Прочее" },
                    { 23, "Кабели" },
                    { 22, "Освещение" },
                    { 21, "Транспорт" },
                    { 20, "Техника для уборки" },
                    { 19, "Умный дом" },
                    { 18, "Медиаплееры" },
                    { 17, "Телевизоры" },
                    { 16, "Сетевое оборудование" },
                    { 15, "Гарнитуры" },
                    { 13, "Мыши компьютерные" },
                    { 14, "Портативная аккустика" },
                    { 11, "Батарейки" },
                    { 10, "Карты памяти" },
                    { 9, "Видеорегистраторы" },
                    { 8, "Ремешки для часов/браслетов" },
                    { 7, "Умные часы/браслеты" },
                    { 6, "Защитные стёкла/плёнки" },
                    { 5, "Чехлы/бампера/книги для телефона" },
                    { 4, "Мобильные телефоны" },
                    { 3, "Рюкзаки/сумки/чемоданы" },
                    { 2, "Ноутбуки" },
                    { 12, "IP-камеры" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "AccessLevel", "Name" },
                values: new object[,]
                {
                    { 2, 2, "Менеджер магазина" },
                    { 1, 5, "Administrator" },
                    { 3, 1, "Продавец" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Login", "Name", "Password", "Patronymic", "PositionId", "SecondName" },
                values: new object[] { 1, null, "Admin", "Admin", "Admin", null, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "HelpCategorySearchers",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 20, 14, "колонка" },
                    { 21, 15, "гарнитура" },
                    { 22, 16, "Wi-Fi" },
                    { 23, 17, "телевизор" },
                    { 24, 18, "TV" },
                    { 25, 19, "блок" },
                    { 19, 13, "мышь" },
                    { 26, 19, "кнопка" },
                    { 28, 20, "пылесос" },
                    { 29, 20, "швабра" },
                    { 30, 21, "самокат" },
                    { 31, 21, "велосипед" },
                    { 32, 21, "гироскутер" },
                    { 33, 22, "лампа" },
                    { 27, 19, "датчик" },
                    { 34, 23, "кабель" },
                    { 18, 12, "IP" },
                    { 16, 10, "памяти" },
                    { 2, 2, "ноутбук" },
                    { 3, 3, "рюкзак" },
                    { 4, 3, "сумка" },
                    { 5, 3, "чемодан" },
                    { 6, 4, "телефон" },
                    { 7, 5, "чехол" },
                    { 17, 11, "батар" },
                    { 8, 5, "бампер" },
                    { 10, 6, "стекло" },
                    { 11, 6, "пленка" },
                    { 12, 7, "браслет" },
                    { 13, 7, "часы" },
                    { 14, 8, "ремешок" },
                    { 15, 9, "видеорегистратор" },
                    { 9, 5, "книга" },
                    { 1, 1, "внешний" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateOfInventarisationProduct_ProductsId",
                table: "DateOfInventarisationProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_DateOfInventarisations_EmployeeId",
                table: "DateOfInventarisations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategorySearchers_CategoryId",
                table: "HelpCategorySearchers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateOfInventarisationProduct");

            migrationBuilder.DropTable(
                name: "HelpCategorySearchers");

            migrationBuilder.DropTable(
                name: "DateOfInventarisations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
