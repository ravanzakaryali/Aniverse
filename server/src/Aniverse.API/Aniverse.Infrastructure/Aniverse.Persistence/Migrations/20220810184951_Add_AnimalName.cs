using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aniverse.Persistence.Migrations
{
    public partial class Add_AnimalName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedAnimalname",
                table: "Animals",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "AnimalnameIndex",
                table: "Animals",
                column: "NormalizedAnimalname",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AnimalnameIndex",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "NormalizedAnimalname",
                table: "Animals");
        }
    }
}
