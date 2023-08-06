using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment02.EntityProviders.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Author_Email",
                table: "Author",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Author_Email",
                table: "Author");
        }
    }
}
