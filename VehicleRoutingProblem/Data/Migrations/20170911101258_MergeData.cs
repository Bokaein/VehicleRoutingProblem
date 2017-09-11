using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleRoutingProblem.Data.Migrations
{
    public partial class MergeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyInfoID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FristName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "AspNetUsers",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SentEmail",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SentSMS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "uniqe_UserNameAndCompany",
                table: "AspNetUsers",
                columns: new[] { "UserName", "CompanyInfoID" });

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
                name: "tbCompanyInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: false),
                    Icon = table.Column<byte[]>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCompanyInfos", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "tbRegister_AccountTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountTypeID = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    UsersId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRegister_AccountTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbRegister_AccountTypes_tbAccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "tbAccountTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbRegister_AccountTypes_AspNetUsers_UsersId1",
                        column: x => x.UsersId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_tbUserLogs_RegisterViewModel_RegisterViewModelID",
                        column: x => x.RegisterViewModelID,
                        principalTable: "RegisterViewModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbUserLogs_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyInfoID",
                table: "AspNetUsers",
                column: "CompanyInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_tbRegister_AccountTypes_AccountTypeID",
                table: "tbRegister_AccountTypes",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbRegister_AccountTypes_UsersId1",
                table: "tbRegister_AccountTypes",
                column: "UsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserLogs_RegisterViewModelID",
                table: "tbUserLogs",
                column: "RegisterViewModelID");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserLogs_UsersId",
                table: "tbUserLogs",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tbCompanyInfos_CompanyInfoID",
                table: "AspNetUsers",
                column: "CompanyInfoID",
                principalTable: "tbCompanyInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tbCompanyInfos_CompanyInfoID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbCompanyInfos");

            migrationBuilder.DropTable(
                name: "tbRegister_AccountTypes");

            migrationBuilder.DropTable(
                name: "tbUserLogs");

            migrationBuilder.DropTable(
                name: "tbAccountTypes");

            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropUniqueConstraint(
                name: "uniqe_UserNameAndCompany",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyInfoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyInfoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FristName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SentEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SentSMS",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
