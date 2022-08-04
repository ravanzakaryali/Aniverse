using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aniverse.Persistence.Migrations
{
    public partial class Modified_RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshTokenEndDate",
                table: "AppUser",
                newName: "RefreshTokenExpiryTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "AppUser",
                newName: "RefreshTokenEndDate");
        }
    }
}
