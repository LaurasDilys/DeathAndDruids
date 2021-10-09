using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ExpandingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AthleticsProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyBonus",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StrengthSavingThrowProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AthleticsProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyBonus",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StrengthSavingThrowProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AthleticsProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "ProficiencyBonus",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "StrengthSavingThrowProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "AthleticsProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ProficiencyBonus",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "StrengthSavingThrowProficiency",
                table: "Monsters");
        }
    }
}
