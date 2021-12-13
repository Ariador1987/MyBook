using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.DAL.Migrations
{
    public partial class AddBridgeTableBooks_Authors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books_Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authors_AuthorId",
                table: "Books_Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authors_BookId",
                table: "Books_Authors",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books_Authors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "PublisherId", "Rating", "Title" },
                values: new object[] { 1, "First Author", "https...", new DateTime(2021, 12, 13, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2579), new DateTime(2021, 12, 3, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2538), "1st Book Description", "Biography", true, 0, 4, "1st Book Title" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "PublisherId", "Rating", "Title" },
                values: new object[] { 2, "Second Author", "https...", new DateTime(2021, 12, 13, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2583), new DateTime(2021, 12, 3, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2583), "2nd Book Description", "Biography", true, 0, 4, "2nd Book Title" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "PublisherId", "Rating", "Title" },
                values: new object[] { 3, "Third Author", "https...", new DateTime(2021, 12, 13, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2587), new DateTime(2021, 12, 3, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2587), "3rd Book Description", "Biography", true, 0, 3, "3rd Book Title" });
        }
    }
}
