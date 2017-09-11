using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleRoutingProblem.Data.Migrations
{
    public partial class MergeData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbUserLogs_RegisterViewModel_RegisterViewModelID",
                table: "tbUserLogs");

            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropIndex(
                name: "IX_tbUserLogs_RegisterViewModelID",
                table: "tbUserLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FristName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbUserLogs_RegisterViewModelID",
                table: "tbUserLogs",
                column: "RegisterViewModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbUserLogs_RegisterViewModel_RegisterViewModelID",
                table: "tbUserLogs",
                column: "RegisterViewModelID",
                principalTable: "RegisterViewModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
