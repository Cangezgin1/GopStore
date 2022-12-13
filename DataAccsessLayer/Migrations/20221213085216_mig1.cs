using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setlers",
                columns: table => new
                {
                    SetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SetBilgisi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Sinif = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setlers", x => x.SetID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İsim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TCKimlikNumarasi = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    OkulNumarasi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Sinif = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Users_Setler",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Setler", x => new { x.UserID, x.SetID });
                    table.ForeignKey(
                        name: "FK_Users_Setler_Setlers_SetID",
                        column: x => x.SetID,
                        principalTable: "Setlers",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Setler_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Setler_SetID",
                table: "Users_Setler",
                column: "SetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Setler");

            migrationBuilder.DropTable(
                name: "Setlers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
