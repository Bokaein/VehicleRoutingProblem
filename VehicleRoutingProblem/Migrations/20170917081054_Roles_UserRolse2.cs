using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRoutingProblem.Migrations
{
    public partial class Roles_UserRolse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolesId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RolesId1",
                table: "AspNetUserRoles",
                column: "RolesId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UsersId1",
                table: "AspNetUserRoles",
                column: "UsersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RolesId1",
                table: "AspNetUserRoles",
                column: "RolesId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsersId1",
                table: "AspNetUserRoles",
                column: "UsersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RolesId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsersId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RolesId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UsersId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RolesId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "AspNetUserRoles");
        }
    }
}
