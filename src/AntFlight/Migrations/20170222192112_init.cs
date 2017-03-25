using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntFlight.Migrations
{
    public partial class init : Migration
    {
        protected override void Up (MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightMessagesDiscr" ,
                columns: table => new
                {
                    FlightMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy" , SqlServerValueGenerationStrategy.IdentityColumn) ,
                    Description = table.Column<string>(nullable: true)
                } ,
                constraints: table => {
                    table.PrimaryKey("PK_FlightMessagesDiscr" , x => x.FlightMessageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OriginalFlightTime");

            migrationBuilder.DropTable(
                name: "FlightMessages");

            migrationBuilder.DropTable(
                name: "FlightMessagesDiscr");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ants");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subgenuses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genuses");

            migrationBuilder.DropTable(
                name: "Subfamilies");
        }
    }
}
