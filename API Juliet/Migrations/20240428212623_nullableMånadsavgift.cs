using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Juliet.Migrations
{
    /// <inheritdoc />
    public partial class nullableMånadsavgift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Månadsavgift",
                table: "Bostäder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Månadsavgift",
                table: "Bostäder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
