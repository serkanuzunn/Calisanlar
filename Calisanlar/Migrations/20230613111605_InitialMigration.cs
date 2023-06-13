using Microsoft.EntityFrameworkCore.Migrations;

namespace Calisanlar.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(nullable: true),
                    SicilNo = table.Column<string>(nullable: true),
                    UstId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Calisanlar_UstId",
                        column: x => x.UstId,
                        principalTable: "Calisanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_UstId",
                table: "Calisanlar",
                column: "UstId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisanlar");
        }
    }
}
