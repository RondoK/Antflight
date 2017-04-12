using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntFlight.Migrations
{
    public partial class FlightMessageDescriptionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightMessages_AspNetUsers_UserId",
                table: "FlightMessages");

            migrationBuilder.AddColumn<string>(
                name: "FlightIntensity",
                table: "FlightMessagesDiscr",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Precipitation",
                table: "FlightMessagesDiscr",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sky",
                table: "FlightMessagesDiscr",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "FlightMessagesDiscr",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terrain",
                table: "FlightMessagesDiscr",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wind",
                table: "FlightMessagesDiscr",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FlightMessages",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GenusName",
                table: "Genuses",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName",
                table: "Ants",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightMessages_AspNetUsers_UserId",
                table: "FlightMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightMessages_AspNetUsers_UserId",
                table: "FlightMessages");

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
                name: "UserId",
                table: "FlightMessages",
                maxLength: 450,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                maxLength: 30,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "GenusName",
                table: "Genuses",
                maxLength: 30,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName",
                table: "Ants",
                maxLength: 60,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightMessages_AspNetUsers_UserId",
                table: "FlightMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
