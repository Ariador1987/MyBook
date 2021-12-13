using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.DAL.Migrations
{
    public partial class AddPublishersTblAndFkRelationshipToBookTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "DateRead" },
                values: new object[] { new DateTime(2021, 12, 13, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2579), new DateTime(2021, 12, 3, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "DateRead" },
                values: new object[] { new DateTime(2021, 12, 13, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2583), new DateTime(2021, 12, 3, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "DateRead" },
                values: new object[] { new DateTime(2021, 12, 13, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2587), new DateTime(2021, 12, 3, 13, 56, 24, 499, DateTimeKind.Local).AddTicks(2587) });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "DateRead" },
                values: new object[] { new DateTime(2021, 12, 9, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8252), new DateTime(2021, 11, 29, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8215) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "DateRead" },
                values: new object[] { new DateTime(2021, 12, 9, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8260), new DateTime(2021, 11, 29, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "DateRead" },
                values: new object[] { new DateTime(2021, 12, 9, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8264), new DateTime(2021, 11, 29, 12, 30, 7, 498, DateTimeKind.Local).AddTicks(8260) });
        }
    }
}
