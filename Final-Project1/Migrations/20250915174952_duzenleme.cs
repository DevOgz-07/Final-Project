using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project1.Migrations
{
    /// <inheritdoc />
    public partial class duzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Rezurations_RezervationId",
                table: "Details");

            migrationBuilder.AlterColumn<int>(
                name: "RezervationId",
                table: "Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Rezurations_RezervationId",
                table: "Details",
                column: "RezervationId",
                principalTable: "Rezurations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Rezurations_RezervationId",
                table: "Details");

            migrationBuilder.AlterColumn<int>(
                name: "RezervationId",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Rezurations_RezervationId",
                table: "Details",
                column: "RezervationId",
                principalTable: "Rezurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
