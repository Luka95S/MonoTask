using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mono.DAL.Migrations
{
    public partial class initial : Migration
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
                    VehicleMakeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Abrv = table.Column<string>(nullable: true),
                    VehicleMakesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleMakes_VehicleMakesId",
                        column: x => x.VehicleMakesId,
                        principalSchema: "Mono",
                        principalTable: "VehicleMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleMakesId",
                schema: "Mono",
                table: "Vehicles",
                column: "VehicleMakesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "Mono");

            migrationBuilder.DropTable(
                name: "VehicleMakes",
                schema: "Mono");
        }
    }
}
