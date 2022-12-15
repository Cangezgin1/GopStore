using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsessLayer.Migrations
{
    public partial class mig2_addedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Setler");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "StudentID");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İsim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdminMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdminŞifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Students_Setler",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students_Setler", x => new { x.StudentID, x.SetID });
                    table.ForeignKey(
                        name: "FK_Students_Setler_Setlers_SetID",
                        column: x => x.SetID,
                        principalTable: "Setlers",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Setler_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Setler_SetID",
                table: "Students_Setler",
                column: "SetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Students_Setler");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Users",
                newName: "UserID");

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
    }
}
