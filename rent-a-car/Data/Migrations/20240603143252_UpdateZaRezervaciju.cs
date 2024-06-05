using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_a_car.Data.Migrations
{
    public partial class UpdateZaRezervaciju : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportnoVozilo_Tip",
                table: "Vozila",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NarucilacId",
                table: "Rezervacija",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportnoVozilo_Tip",
                table: "Vozila");

            migrationBuilder.AlterColumn<int>(
                name: "NarucilacId",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
