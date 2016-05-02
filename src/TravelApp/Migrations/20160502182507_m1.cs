using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TravelApp.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DateCreated", table: "Trip");
            migrationBuilder.DropColumn(name: "ArrivalDate", table: "Stop");
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Stop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Trip");
            migrationBuilder.DropColumn(name: "Arrival", table: "Stop");
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Stop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
