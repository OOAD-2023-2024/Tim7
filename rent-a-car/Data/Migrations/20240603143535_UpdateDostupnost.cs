using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_a_car.Data.Migrations
{
    public partial class UpdateDostupnost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dostupno",
                table: "Vozila",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dostupno",
                table: "Vozila");
        }
    }
}
