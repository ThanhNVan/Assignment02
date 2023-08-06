using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment02.EntityProviders.Migrations
{
    public partial class addbookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoyalityPercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookAuthor_Author = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookAuthor_Book = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Author_BookAuthor_Author",
                        column: x => x.BookAuthor_Author,
                        principalTable: "Author",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookAuthor_Book",
                        column: x => x.BookAuthor_Book,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookAuthor_Author",
                table: "BookAuthors",
                column: "BookAuthor_Author");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookAuthor_Book",
                table: "BookAuthors",
                column: "BookAuthor_Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");
        }
    }
}
