using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_a_car.Data.Migrations
{
    public partial class UpdateVozila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportnoVozilo_Tip",
                table: "Vozila",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportnoVozilo_Tip",
                table: "Vozila");
        }
    }
}
