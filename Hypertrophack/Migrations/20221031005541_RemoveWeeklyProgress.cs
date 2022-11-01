using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hypertrophack.Migrations
{
    public partial class RemoveWeeklyProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyProgress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmSets = table.Column<int>(type: "int", nullable: false),
                    BackSets = table.Column<int>(type: "int", nullable: false),
                    ChestSets = table.Column<int>(type: "int", nullable: false),
                    LegSets = table.Column<int>(type: "int", nullable: false),
                    MuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoulderSets = table.Column<int>(type: "int", nullable: false),
                    WeekStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyProgress", x => x.Id);
                });
        }
    }
}
