using Microsoft.EntityFrameworkCore.Migrations;

namespace Inve_Time.DataBase.dll.Migrations
{
    public partial class updateInvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CloseToModifi",
                table: "InventarisationEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseToModifi",
                table: "InventarisationEvents");
        }
    }
}
