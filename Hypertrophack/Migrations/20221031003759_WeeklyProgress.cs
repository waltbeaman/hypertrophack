using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hypertrophack.Migrations
{
    public partial class WeeklyProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeekStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChestSets = table.Column<int>(type: "int", nullable: false),
                    BackSets = table.Column<int>(type: "int", nullable: false),
                    LegSets = table.Column<int>(type: "int", nullable: false),
                    ArmSets = table.Column<int>(type: "int", nullable: false),
                    ShoulderSets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyProgress", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyProgress");
        }
    }
}
