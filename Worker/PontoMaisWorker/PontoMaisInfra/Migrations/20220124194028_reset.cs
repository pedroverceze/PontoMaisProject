using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PontoMaisInfra.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockingEvent",
                table: "ClockingEvent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockingEvent",
                table: "ClockingEvent",
                columns: new[] { "Id", "EventNu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockingEvent",
                table: "ClockingEvent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockingEvent",
                table: "ClockingEvent",
                column: "Id");
        }
    }
}
