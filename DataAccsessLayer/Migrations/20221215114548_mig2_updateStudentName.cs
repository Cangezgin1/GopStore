using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccsessLayer.Migrations
{
    public partial class mig2_updateStudentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Setler_Users_StudentID",
                table: "Students_Setler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Setler_Students_StudentID",
                table: "Students_Setler",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Setler_Students_StudentID",
                table: "Students_Setler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Setler_Users_StudentID",
                table: "Students_Setler",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
