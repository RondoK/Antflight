using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntFlight.Migrations
{
    public partial class FMDiscrKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightMessagesDiscr" ,
                columns: table => new {
                    FlightMessageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                } ,
                constraints: table => {
                    table.PrimaryKey("PK_FlightMessagesDiscr" , x => x.FlightMessageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr",
                column: "FlightMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightMessagesDiscr_FlightMessages_FlightMessageId",
                table: "FlightMessagesDiscr",
                column: "FlightMessageId",
                principalTable: "FlightMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightMessagesDiscr_FlightMessages_FlightMessageId",
                table: "FlightMessagesDiscr");

            migrationBuilder.DropIndex(
                name: "IX_FlightMessagesDiscr_FlightMessageId",
                table: "FlightMessagesDiscr");

            migrationBuilder.AlterColumn<int>(
                name: "FlightMessageId",
                table: "FlightMessagesDiscr",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
