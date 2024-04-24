using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Juliet.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BostadKategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BostadKategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kommuner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommuner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mäklarbyråer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Presentation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logotyp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mäklarbyråer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mäklare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MäklarbyråId = table.Column<int>(type: "int", nullable: true),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Epostadress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bild = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mäklare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mäklare_Mäklarbyråer_MäklarbyråId",
                        column: x => x.MäklarbyråId,
                        principalTable: "Mäklarbyråer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bostäder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BostadKategoriId = table.Column<int>(type: "int", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KommunId = table.Column<int>(type: "int", nullable: true),
                    Utgångspris = table.Column<int>(type: "int", nullable: false),
                    Boarea = table.Column<int>(type: "int", nullable: false),
                    Biarea = table.Column<int>(type: "int", nullable: false),
                    Tomtarea = table.Column<int>(type: "int", nullable: false),
                    Objektbeskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antalrum = table.Column<int>(type: "int", nullable: false),
                    Månadsavgift = table.Column<int>(type: "int", nullable: false),
                    Driftkonstnad = table.Column<int>(type: "int", nullable: false),
                    Byggår = table.Column<int>(type: "int", nullable: false),
                    MäklareId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bostäder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bostäder_BostadKategori_BostadKategoriId",
                        column: x => x.BostadKategoriId,
                        principalTable: "BostadKategori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bostäder_Kommuner_KommunId",
                        column: x => x.KommunId,
                        principalTable: "Kommuner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bostäder_Mäklare_MäklareId",
                        column: x => x.MäklareId,
                        principalTable: "Mäklare",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bostäder_BostadKategoriId",
                table: "Bostäder",
                column: "BostadKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Bostäder_KommunId",
                table: "Bostäder",
                column: "KommunId");

            migrationBuilder.CreateIndex(
                name: "IX_Bostäder_MäklareId",
                table: "Bostäder",
                column: "MäklareId");

            migrationBuilder.CreateIndex(
                name: "IX_Mäklare_MäklarbyråId",
                table: "Mäklare",
                column: "MäklarbyråId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bostäder");

            migrationBuilder.DropTable(
                name: "BostadKategori");

            migrationBuilder.DropTable(
                name: "Kommuner");

            migrationBuilder.DropTable(
                name: "Mäklare");

            migrationBuilder.DropTable(
                name: "Mäklarbyråer");
        }
    }
}
