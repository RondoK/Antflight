using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntFlight.Migrations
{
    public partial class discrtodescrname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightMessagesDiscr");

            migrationBuilder.CreateTable(
                name: "FlightMessagesDescr",
                columns: table => new
                {
                    FlightMessageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FlightIntensity = table.Column<byte>(nullable: false),
                    Precipitation = table.Column<byte>(nullable: false),
                    Sky = table.Column<byte>(nullable: false),
                    Temperature = table.Column<byte>(nullable: false),
                    Terrain = table.Column<byte>(nullable: false),
                    Wind = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightMessagesDescr", x => x.FlightMessageId);
                    table.ForeignKey(
                        name: "FK_FlightMessagesDescr_FlightMessages_FlightMessageId",
                        column: x => x.FlightMessageId,
                        principalTable: "FlightMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightMessagesDescr_FlightMessageId",
                table: "FlightMessagesDescr",
                column: "FlightMessageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightMessagesDescr");

            migrationBuilder.CreateTable(
                name: "FlightMessagesDiscr",
                columns: table => new
                {
                    FlightMessageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FlightIntensity = table.Column<byte>(nullable: false),
                    Precipitation = table.Column<byte>(nullable: false),
                    Sky = table.Column<byte>(nullable: false),
                    Temperature = table.Column<byte>(nullable: false),
                    Terrain = table.Column<byte>(nullable: false),
                    Wind = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightMessagesDiscr", x => x.FlightMessageId);
                    table.ForeignKey(
                        name: "FK_FlightMessagesDiscr_FlightMessages_FlightMessageId",
                        column: x => x.FlightMessageId,
                        principalTable: "FlightMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr",
                column: "FlightMessageId",
                unique: true);
        }
    }
}
