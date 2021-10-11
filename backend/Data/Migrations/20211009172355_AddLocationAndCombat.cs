using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddLocationAndCombat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: true),
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
                    PersuasionProficiency = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedTab = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combat");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
