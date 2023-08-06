using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment02.EntityProviders.Migrations
{
    public partial class addmoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Author_BookAuthor_Author",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BookAuthor_Book",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_Book_Publisher",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_User_Role",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Book_Publisher",
                table: "Book",
                newName: "IX_Book_Book_Publisher");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_BookAuthor_Book",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BookAuthor_Book");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_BookAuthor_Author",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BookAuthor_Author");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "BookAuthor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "BookAuthor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId_AuthorId",
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_Book_Publisher",
                table: "Book",
                column: "Book_Publisher",
                principalTable: "Publisher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_BookAuthor_Author",
                table: "BookAuthor",
                column: "BookAuthor_Author",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Book_BookAuthor_Book",
                table: "BookAuthor",
                column: "BookAuthor_Book",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_User_Role",
                table: "User",
                column: "User_Role",
                principalTable: "Role",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_Book_Publisher",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_BookAuthor_Author",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Book_BookAuthor_Book",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_User_Role",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_BookId_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BookAuthor_Book",
                table: "BookAuthors",
                newName: "IX_BookAuthors_BookAuthor_Book");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BookAuthor_Author",
                table: "BookAuthors",
                newName: "IX_BookAuthors_BookAuthor_Author");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Book_Publisher",
                table: "Books",
                newName: "IX_Books_Book_Publisher");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "BookAuthors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "BookAuthors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Author_BookAuthor_Author",
                table: "BookAuthors",
                column: "BookAuthor_Author",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BookAuthor_Book",
                table: "BookAuthors",
                column: "BookAuthor_Book",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_Book_Publisher",
                table: "Books",
                column: "Book_Publisher",
                principalTable: "Publisher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_User_Role",
                table: "User",
                column: "User_Role",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
