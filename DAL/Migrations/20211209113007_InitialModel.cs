using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.DAL.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "Rating", "Title" },
                values: new object[] { 1, "First Author", "https...", new DateTime(2021, 12, 9, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8252), new DateTime(2021, 11, 29, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8215), "1st Book Description", "Biography", true, 4, "1st Book Title" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "Rating", "Title" },
                values: new object[] { 2, "Second Author", "https...", new DateTime(2021, 12, 9, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8260), new DateTime(2021, 11, 29, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8256), "2nd Book Description", "Biography", true, 4, "2nd Book Title" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "Rating", "Title" },
                values: new object[] { 3, "Third Author", "https...", new DateTime(2021, 12, 9, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8264), new DateTime(2021, 11, 29, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8260), "3rd Book Description", "Biography", true, 3, "3rd Book Title" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
