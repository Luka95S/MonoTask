using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mono.DBContext.Migrations
{
    public partial class initalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Mono");

            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                schema: "Mono",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Abrv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "Mono",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MakeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Abrv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleMakes",
                schema: "Mono");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "Mono");
        }
    }
}
