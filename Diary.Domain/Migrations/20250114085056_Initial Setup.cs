using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "CreateDate", "Title" },
                values: new object[,]
                {
                    { 1, "Hiked to the top of a mountain and saw amazing views.", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Went Hiking" },
                    { 2, "Went shopoping with Joe", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Went Shopping" },
                    { 3, "Went diving with Joe", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Went Diving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");
        }
    }
}
