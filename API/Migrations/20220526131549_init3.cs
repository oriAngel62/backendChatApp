using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserName",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_FromUserName",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_ToUserName",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_FromUserName",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ToUserName",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "FromUserName",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ToUserName",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Message",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Message",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Message",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Contact",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Contact",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserName",
                table: "Contact",
                column: "UserName",
                principalTable: "User",
                principalColumn: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserName",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Contact");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FromUserName",
                table: "Message",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ToUserName",
                table: "Message",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "UserName",
                keyValue: null,
                column: "UserName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Contact",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromUserName",
                table: "Message",
                column: "FromUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ToUserName",
                table: "Message",
                column: "ToUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserName",
                table: "Contact",
                column: "UserName",
                principalTable: "User",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_FromUserName",
                table: "Message",
                column: "FromUserName",
                principalTable: "User",
                principalColumn: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_ToUserName",
                table: "Message",
                column: "ToUserName",
                principalTable: "User",
                principalColumn: "UserName");
        }
    }
}
