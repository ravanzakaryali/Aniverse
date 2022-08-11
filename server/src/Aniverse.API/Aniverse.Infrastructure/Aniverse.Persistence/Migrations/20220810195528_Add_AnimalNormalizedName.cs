using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aniverse.Persistence.Migrations
{
    public partial class Add_AnimalNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Animals_Animalname",
                table: "Animals",
                column: "Animalname",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Animals_Animalname",
                table: "Animals");
        }
    }
}
