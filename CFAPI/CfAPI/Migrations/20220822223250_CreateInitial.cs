using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CfAPI.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CFs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Indice = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IndiceSpecial = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titres_CFs_CfId",
                        column: x => x.CfId,
                        principalTable: "CFs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titres_CfId",
                table: "Titres",
                column: "CfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titres");

            migrationBuilder.DropTable(
                name: "CFs");
        }
    }
}
