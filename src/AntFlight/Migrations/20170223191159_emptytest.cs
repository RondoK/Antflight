using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntFlight.Migrations
{
    public partial class emptytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr");

            migrationBuilder.CreateIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr",
                column: "FlightMessageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr");

            migrationBuilder.CreateIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr",
                column: "FlightMessageId");
        }
    }
}
