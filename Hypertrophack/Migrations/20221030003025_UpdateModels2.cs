using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hypertrophack.Migrations
{
    public partial class UpdateModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedExercises_MuscleGroups_MuscleGroupId",
                table: "CompletedExercises");

            migrationBuilder.DropIndex(
                name: "IX_CompletedExercises_MuscleGroupId",
                table: "CompletedExercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroupId",
                table: "CompletedExercises");

            migrationBuilder.AddColumn<string>(
                name: "MuscleGroup",
                table: "CompletedExercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MuscleGroup",
                table: "CompletedExercises");

            migrationBuilder.AddColumn<int>(
                name: "MuscleGroupId",
                table: "CompletedExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedExercises_MuscleGroupId",
                table: "CompletedExercises",
                column: "MuscleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedExercises_MuscleGroups_MuscleGroupId",
                table: "CompletedExercises",
                column: "MuscleGroupId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
