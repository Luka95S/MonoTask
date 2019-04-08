using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mono.DAL.Migrations
{
    public partial class removed_make_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleMakeId",
                schema: "Mono",
                table: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VehicleMakeId",
                schema: "Mono",
                table: "Vehicles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
