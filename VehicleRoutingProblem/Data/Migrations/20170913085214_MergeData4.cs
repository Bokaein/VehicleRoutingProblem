using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRoutingProblem.Data.Migrations
{
    public partial class MergeData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbRegister_AccountTypes_tbAccountTypes_AccountTypeID",
                table: "tbRegister_AccountTypes");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "tbRegister_AccountTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AccountTypeID",
                table: "tbRegister_AccountTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tbRegister_AccountTypes_tbAccountTypes_AccountTypeID",
                table: "tbRegister_AccountTypes",
                column: "AccountTypeID",
                principalTable: "tbAccountTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbRegister_AccountTypes_tbAccountTypes_AccountTypeID",
                table: "tbRegister_AccountTypes");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "tbRegister_AccountTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountTypeID",
                table: "tbRegister_AccountTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbRegister_AccountTypes_tbAccountTypes_AccountTypeID",
                table: "tbRegister_AccountTypes",
                column: "AccountTypeID",
                principalTable: "tbAccountTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
