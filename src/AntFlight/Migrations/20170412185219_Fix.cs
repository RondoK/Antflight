using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntFlight.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightIntensity",
                table: "FlightMessagesDiscr");

            migrationBuilder.DropColumn(
                name: "Precipitation",
                table: "FlightMessagesDiscr");

            migrationBuilder.DropColumn(
                name: "Sky",
                table: "FlightMessagesDiscr");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "FlightMessagesDiscr");

            migrationBuilder.DropColumn(
                name: "Terrain",
                table: "FlightMessagesDiscr");

            migrationBuilder.DropColumn(
                name: "Wind",
                table: "FlightMessagesDiscr");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FlightMessagesDiscr",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "FlightIntensity",
                table: "FlightMessagesDiscr",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Precipitation",
                table: "FlightMessagesDiscr",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Sky",
                table: "FlightMessagesDiscr",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Temperature",
                table: "FlightMessagesDiscr",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Terrain",
                table: "FlightMessagesDiscr",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Wind",
                table: "FlightMessagesDiscr",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<byte>(
                name: "Description",
                table: "FlightMessagesDiscr",
                nullable: false);
        }
    }
}
