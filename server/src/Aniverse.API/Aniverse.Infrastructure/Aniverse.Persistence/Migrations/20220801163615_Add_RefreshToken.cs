using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aniverse.Persistence.Migrations
{
    public partial class Add_RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AppUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenEndDate",
                table: "AppUser",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "RefreshTokenEndDate",
                table: "AppUser");
        }
    }
}
