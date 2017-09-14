using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleRoutingProblem.Migrations
{
    public partial class RefineDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbRegister_AccountTypes");

            migrationBuilder.DropTable(
                name: "tbUserLogs");

            migrationBuilder.DropTable(
                name: "tbAccountTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAccountTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAccountTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbUserLogs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogIn = table.Column<DateTime>(nullable: true),
                    LogOut = table.Column<DateTime>(nullable: true),
                    RegisterViewModelID = table.Column<int>(nullable: false),
                    UsersId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbUserLogs_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbRegister_AccountTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountTypeID = table.Column<int>(nullable: true),
                    UsersId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRegister_AccountTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbRegister_AccountTypes_tbAccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "tbAccountTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbRegister_AccountTypes_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbRegister_AccountTypes_AccountTypeID",
                table: "tbRegister_AccountTypes",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbRegister_AccountTypes_UsersId",
                table: "tbRegister_AccountTypes",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserLogs_UsersId",
                table: "tbUserLogs",
                column: "UsersId");
        }
    }
}
