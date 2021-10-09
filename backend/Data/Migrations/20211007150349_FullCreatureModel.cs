using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FullCreatureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcrobaticsProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "OpenedMonsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnimalHandlingProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArcanaProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ChallengeRating",
                table: "OpenedMonsters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Charisma",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CharismaSavingThrowProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ConstitutionSavingThrowProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CurrentArmorClass",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHitPoints",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSpeed",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DeceptionProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DexteritySavingThrowProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HistoryProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InsightProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IntelligenceSavingThrowProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IntimidationProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvestigationProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicineProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NatureProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "OpenedMonsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PerceptionProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PerformanceProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PersuasionProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReligionProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SleightOfHandProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StealthProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SurvivalProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TemporaryHitPoints",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Traits",
                table: "OpenedMonsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wisdom",
                table: "OpenedMonsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WisdomSavingThrowProficiency",
                table: "OpenedMonsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcrobaticsProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnimalHandlingProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArcanaProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ChallengeRating",
                table: "Monsters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Charisma",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CharismaSavingThrowProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ConstitutionSavingThrowProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CurrentArmorClass",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHitPoints",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSpeed",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DeceptionProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DexteritySavingThrowProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HistoryProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InsightProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IntelligenceSavingThrowProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IntimidationProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvestigationProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicineProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NatureProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PerceptionProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PerformanceProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PersuasionProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReligionProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SleightOfHandProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StealthProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SurvivalProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TemporaryHitPoints",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Traits",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wisdom",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WisdomSavingThrowProficiency",
                table: "Monsters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcrobaticsProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "AnimalHandlingProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "ArcanaProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "ChallengeRating",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Charisma",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "CharismaSavingThrowProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Constitution",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "ConstitutionSavingThrowProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "CurrentArmorClass",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "CurrentHitPoints",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "CurrentSpeed",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "DeceptionProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "DexteritySavingThrowProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "HistoryProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "InsightProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "IntelligenceSavingThrowProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "IntimidationProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "InvestigationProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "MedicineProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "NatureProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "PerceptionProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "PerformanceProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "PersuasionProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "ReligionProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "SleightOfHandProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "StealthProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "SurvivalProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "TemporaryHitPoints",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Traits",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "Wisdom",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "WisdomSavingThrowProficiency",
                table: "OpenedMonsters");

            migrationBuilder.DropColumn(
                name: "AcrobaticsProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "AnimalHandlingProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ArcanaProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ChallengeRating",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Charisma",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "CharismaSavingThrowProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Constitution",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ConstitutionSavingThrowProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "CurrentArmorClass",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "CurrentHitPoints",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "CurrentSpeed",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DeceptionProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DexteritySavingThrowProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "HistoryProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "InsightProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IntelligenceSavingThrowProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IntimidationProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "InvestigationProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MedicineProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "NatureProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "PerceptionProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "PerformanceProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "PersuasionProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ReligionProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SleightOfHandProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "StealthProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SurvivalProficiency",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "TemporaryHitPoints",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Traits",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Wisdom",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "WisdomSavingThrowProficiency",
                table: "Monsters");
        }
    }
}
