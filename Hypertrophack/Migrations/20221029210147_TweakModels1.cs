using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hypertrophack.Migrations
{
    public partial class TweakModels1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MuscleGroupName",
                table: "CompletedExercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MuscleGroupName",
                table: "CompletedExercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
