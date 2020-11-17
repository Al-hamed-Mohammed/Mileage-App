using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MileageApp.Migrations
{
    public partial class InitialCreateGood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    TravelDate = table.Column<DateTime>(nullable: false),
                    Client = table.Column<string>(nullable: true),
                    StartToEnd = table.Column<string>(nullable: true),
                    Miles = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
