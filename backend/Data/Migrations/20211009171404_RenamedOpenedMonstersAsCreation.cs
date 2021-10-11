using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RenamedOpenedMonstersAsCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenedMonsters");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.CreateTable(
                name: "Creation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saved = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChallengeRating = table.Column<double>(type: "float", nullable: false),
                    ProficiencyBonus = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    CurrentArmorClass = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentHitPoints = table.Column<int>(type: "int", nullable: false),
                    TemporaryHitPoints = table.Column<int>(type: "int", nullable: false),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    CurrentSpeed = table.Column<int>(type: "int", nullable: false),
                    Traits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    StrengthSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    AthleticsProficiency = table.Column<bool>(type: "bit", nullable: false),
                    DexteritySavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    AcrobaticsProficiency = table.Column<bool>(type: "bit", nullable: false),
                    SleightOfHandProficiency = table.Column<bool>(type: "bit", nullable: false),
                    StealthProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ConstitutionSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    IntelligenceSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ArcanaProficiency = table.Column<bool>(type: "bit", nullable: false),
                    HistoryProficiency = table.Column<bool>(type: "bit", nullable: false),
                    InvestigationProficiency = table.Column<bool>(type: "bit", nullable: false),
                    NatureProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ReligionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    WisdomSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    AnimalHandlingProficiency = table.Column<bool>(type: "bit", nullable: false),
                    InsightProficiency = table.Column<bool>(type: "bit", nullable: false),
                    MedicineProficiency = table.Column<bool>(type: "bit", nullable: false),
                    PerceptionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    SurvivalProficiency = table.Column<bool>(type: "bit", nullable: false),
                    CharismaSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    DeceptionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    IntimidationProficiency = table.Column<bool>(type: "bit", nullable: false),
                    PerformanceProficiency = table.Column<bool>(type: "bit", nullable: false),
                    PersuasionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creation");

            migrationBuilder.CreateTable(
                name: "OpenedMonsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcrobaticsProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalHandlingProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ArcanaProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    AthleticsProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ChallengeRating = table.Column<double>(type: "float", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    CharismaSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    ConstitutionSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    CurrentArmorClass = table.Column<int>(type: "int", nullable: false),
                    CurrentHitPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentSpeed = table.Column<int>(type: "int", nullable: false),
                    DeceptionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    DexteritySavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    HistoryProficiency = table.Column<bool>(type: "bit", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    InsightProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    IntelligenceSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    IntimidationProficiency = table.Column<bool>(type: "bit", nullable: false),
                    InvestigationProficiency = table.Column<bool>(type: "bit", nullable: false),
                    MedicineProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerceptionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    PerformanceProficiency = table.Column<bool>(type: "bit", nullable: false),
                    PersuasionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    ProficiencyBonus = table.Column<int>(type: "int", nullable: false),
                    ReligionProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Saved = table.Column<bool>(type: "bit", nullable: false),
                    SleightOfHandProficiency = table.Column<bool>(type: "bit", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    StealthProficiency = table.Column<bool>(type: "bit", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    StrengthSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false),
                    SurvivalProficiency = table.Column<bool>(type: "bit", nullable: false),
                    TemporaryHitPoints = table.Column<int>(type: "int", nullable: false),
                    Traits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    WisdomSavingThrowProficiency = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenedMonsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CombatId = table.Column<int>(type: "int", nullable: true),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CombatId", "Initiative", "Name", "Type" },
                values: new object[] { 1, null, 0, null, null });
        }
    }
}
