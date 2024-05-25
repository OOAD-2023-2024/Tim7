using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_a_car.Data.Migrations
{
    public partial class UpdateZaVozilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila");

            migrationBuilder.DropColumn(
                name: "PutnickoVozilo_Tip",
                table: "Vozila");

            migrationBuilder.AlterColumn<int>(
                name: "Tip",
                table: "Vozila",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slika",
                table: "Vozila",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Poslovnica",
                table: "Vozila",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila",
                column: "Poslovnica",
                principalTable: "Poslovnica",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila");

            migrationBuilder.AlterColumn<int>(
                name: "Tip",
                table: "Vozila",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Slika",
                table: "Vozila",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Poslovnica",
                table: "Vozila",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PutnickoVozilo_Tip",
                table: "Vozila",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila",
                column: "Poslovnica",
                principalTable: "Poslovnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
