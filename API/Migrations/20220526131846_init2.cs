using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserName",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_UserName",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Contact",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName1",
                table: "Contact",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserName1",
                table: "Contact",
                column: "UserName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserName1",
                table: "Contact",
                column: "UserName1",
                principalTable: "User",
                principalColumn: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserName1",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_UserName1",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "UserName1",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Contact",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Contact",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserName",
                table: "Contact",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserName",
                table: "Contact",
                column: "UserName",
                principalTable: "User",
                principalColumn: "UserName");
        }
    }
}
