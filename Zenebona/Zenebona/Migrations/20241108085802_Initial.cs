using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Zenebona.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Eloadok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    Nemzetiseg = table.Column<string>(type: "longtext", nullable: false),
                    Elo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eloadok", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kiadok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    AlapitasEve = table.Column<short>(type: "smallint", nullable: false),
                    Cim = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiadok", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zeneszamok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: true),
                    MegjelenesEve = table.Column<int>(type: "int", nullable: false),
                    LejatszasiIdo = table.Column<double>(type: "double", nullable: false),
                    Jogdijas = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EloadoId = table.Column<int>(type: "int", nullable: true),
                    KiadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zeneszamok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zeneszamok_Eloadok_EloadoId",
                        column: x => x.EloadoId,
                        principalTable: "Eloadok",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zeneszamok_Kiadok_KiadoId",
                        column: x => x.KiadoId,
                        principalTable: "Kiadok",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Zeneszamok_EloadoId",
                table: "Zeneszamok",
                column: "EloadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Zeneszamok_KiadoId",
                table: "Zeneszamok",
                column: "KiadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zeneszamok");

            migrationBuilder.DropTable(
                name: "Eloadok");

            migrationBuilder.DropTable(
                name: "Kiadok");
        }
    }
}
