using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_a_car.Data.Migrations
{
    public partial class UpdateDrugeMigracije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila");

            migrationBuilder.AlterColumn<int>(
                name: "Poslovnica",
                table: "Vozila",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila",
                column: "Poslovnica",
                principalTable: "Poslovnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vozila_Poslovnica_Poslovnica",
                table: "Vozila");

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
    }
}
