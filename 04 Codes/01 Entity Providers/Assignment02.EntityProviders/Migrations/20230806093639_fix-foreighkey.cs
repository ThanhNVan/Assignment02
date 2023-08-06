using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment02.EntityProviders.Migrations
{
    public partial class fixforeighkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "User_Publisher",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Role",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Book_Publisher",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_User_Publisher",
                table: "User",
                column: "User_Publisher");

            migrationBuilder.CreateIndex(
                name: "IX_User_User_Role",
                table: "User",
                column: "User_Role");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Book_Publisher",
                table: "Books",
                column: "Book_Publisher");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_Book_Publisher",
                table: "Books",
                column: "Book_Publisher",
                principalTable: "Publisher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Publisher_User_Publisher",
                table: "User",
                column: "User_Publisher",
                principalTable: "Publisher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_User_Role",
                table: "User",
                column: "User_Role",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_Book_Publisher",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Publisher_User_Publisher",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_User_Role",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_User_Publisher",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_User_Role",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Books_Book_Publisher",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "User_Publisher",
                table: "User");

            migrationBuilder.DropColumn(
                name: "User_Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Book_Publisher",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
