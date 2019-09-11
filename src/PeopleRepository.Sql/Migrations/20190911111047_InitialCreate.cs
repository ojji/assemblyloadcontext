using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleRepository.Sql.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.LastName);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "LastName", "FirstName", "Rating", "StartDate" },
                values: new object[,]
                {
                    { "Elmer", "John", 6, new DateTime(1975, 10, 17, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Hunt", "Francis", 7, new DateTime(2000, 2, 6, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Montana", "Amanda", 6, new DateTime(1999, 8, 25, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Sheridan", "Steven", 8, new DateTime(1991, 11, 11, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Gampu", "Eleanor", 5, new DateTime(1996, 12, 9, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Koenig", "Paul", 9, new DateTime(1981, 4, 20, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Lister", "Gabriela", 4, new DateTime(1984, 4, 19, 22, 20, 29, 55, DateTimeKind.Utc) },
                    { "Stephens", "Petra", 9, new DateTime(2005, 2, 10, 22, 20, 29, 55, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
