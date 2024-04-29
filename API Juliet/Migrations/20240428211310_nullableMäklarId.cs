using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Juliet.Migrations
{
    /// <inheritdoc />
    public partial class nullableMäklarId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bostäder_Mäklare_MäklareId",
                table: "Bostäder");

            migrationBuilder.AlterColumn<int>(
                name: "MäklareId",
                table: "Bostäder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bostäder_Mäklare_MäklareId",
                table: "Bostäder",
                column: "MäklareId",
                principalTable: "Mäklare",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bostäder_Mäklare_MäklareId",
                table: "Bostäder");

            migrationBuilder.AlterColumn<int>(
                name: "MäklareId",
                table: "Bostäder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bostäder_Mäklare_MäklareId",
                table: "Bostäder",
                column: "MäklareId",
                principalTable: "Mäklare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
