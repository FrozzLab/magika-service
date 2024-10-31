using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FP_EN_Brusnikau_s24109.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arcane_Domains",
                columns: table => new
                {
                    IdArcaneDomain = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    AuraType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arcane_Domains", x => x.IdArcaneDomain);
                });

            migrationBuilder.CreateTable(
                name: "Arcane_Schools",
                columns: table => new
                {
                    IdArcaneSchool = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    EnrollmentLengthByDegree = table.Column<string>(type: "TEXT", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arcane_Schools", x => x.IdArcaneSchool);
                });

            migrationBuilder.CreateTable(
                name: "Benefactors",
                columns: table => new
                {
                    IdBenefactor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefactors", x => x.IdBenefactor);
                });

            migrationBuilder.CreateTable(
                name: "Spell_Effects",
                columns: table => new
                {
                    IdSpellEffect = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EffectType = table.Column<int>(type: "INTEGER", nullable: false),
                    ImmuneCreatures = table.Column<string>(type: "TEXT", nullable: false),
                    Potency = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell_Effects", x => x.IdSpellEffect);
                });

            migrationBuilder.CreateTable(
                name: "Mages",
                columns: table => new
                {
                    IdMage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    TotalPowerLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdSoulBoundDomain = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mages", x => x.IdMage);
                    table.ForeignKey(
                        name: "FK_Mages_Arcane_Domains_IdSoulBoundDomain",
                        column: x => x.IdSoulBoundDomain,
                        principalTable: "Arcane_Domains",
                        principalColumn: "IdArcaneDomain");
                });

            migrationBuilder.CreateTable(
                name: "Forbidding_Schools_Domains",
                columns: table => new
                {
                    IdArcaneSchool = table.Column<int>(type: "INTEGER", nullable: false),
                    IdArcaneDomain = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forbidding_Schools_Domains", x => new { x.IdArcaneSchool, x.IdArcaneDomain });
                    table.ForeignKey(
                        name: "FK_Forbidding_Schools_Domains_Arcane_Domains_IdArcaneDomain",
                        column: x => x.IdArcaneDomain,
                        principalTable: "Arcane_Domains",
                        principalColumn: "IdArcaneDomain",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forbidding_Schools_Domains_Arcane_Schools_IdArcaneSchool",
                        column: x => x.IdArcaneSchool,
                        principalTable: "Arcane_Schools",
                        principalColumn: "IdArcaneSchool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teaching_Schools_Domains",
                columns: table => new
                {
                    IdArcaneSchool = table.Column<int>(type: "INTEGER", nullable: false),
                    IdArcaneDomain = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaching_Schools_Domains", x => new { x.IdArcaneSchool, x.IdArcaneDomain });
                    table.ForeignKey(
                        name: "FK_Teaching_Schools_Domains_Arcane_Domains_IdArcaneDomain",
                        column: x => x.IdArcaneDomain,
                        principalTable: "Arcane_Domains",
                        principalColumn: "IdArcaneDomain",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teaching_Schools_Domains_Arcane_Schools_IdArcaneSchool",
                        column: x => x.IdArcaneSchool,
                        principalTable: "Arcane_Schools",
                        principalColumn: "IdArcaneSchool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    IdBenefactor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuccessionOrder = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefactors", x => x.IdBenefactor);
                    table.ForeignKey(
                        name: "FK_Kingdoms_Benefactors_IdBenefactor",
                        column: x => x.IdBenefactor,
                        principalTable: "Benefactors",
                        principalColumn: "IdBenefactor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Damaging_Effects",
                columns: table => new
                {
                    IdSpellEffect = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DamageTarget = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell_Effects", x => x.IdSpellEffect);
                    table.ForeignKey(
                        name: "FK_Damaging_Effects_Spell_Effects_IdSpellEffect",
                        column: x => x.IdSpellEffect,
                        principalTable: "Spell_Effects",
                        principalColumn: "IdSpellEffect",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restorative_Effects",
                columns: table => new
                {
                    IdSpellEffect = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuredAilments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell_Effects", x => x.IdSpellEffect);
                    table.ForeignKey(
                        name: "FK_Restorative_Effects_Spell_Effects_IdSpellEffect",
                        column: x => x.IdSpellEffect,
                        principalTable: "Spell_Effects",
                        principalColumn: "IdSpellEffect",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Special_Effects",
                columns: table => new
                {
                    IdSpellEffect = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EffectDesctiption = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell_Effects", x => x.IdSpellEffect);
                    table.ForeignKey(
                        name: "FK_Special_Effects_Spell_Effects_IdSpellEffect",
                        column: x => x.IdSpellEffect,
                        principalTable: "Spell_Effects",
                        principalColumn: "IdSpellEffect",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PowerLevelCost = table.Column<int>(type: "INTEGER", nullable: false),
                    IdArcaneDomain = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSpellEffect = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.IdSpell);
                    table.ForeignKey(
                        name: "FK_Spells_Arcane_Domains_IdArcaneDomain",
                        column: x => x.IdArcaneDomain,
                        principalTable: "Arcane_Domains",
                        principalColumn: "IdArcaneDomain",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spells_Spell_Effects_IdSpell",
                        column: x => x.IdSpell,
                        principalTable: "Spell_Effects",
                        principalColumn: "IdSpellEffect",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    IdApplication = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Goal = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    OfferHistory = table.Column<string>(type: "TEXT", nullable: false),
                    NextToRespond = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IdBenefactor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.IdApplication);
                    table.ForeignKey(
                        name: "FK_Applications_Benefactors_IdBenefactor",
                        column: x => x.IdBenefactor,
                        principalTable: "Benefactors",
                        principalColumn: "IdBenefactor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Mages_IdMage",
                        column: x => x.IdMage,
                        principalTable: "Mages",
                        principalColumn: "IdMage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    IdEnrollment = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DegreeType = table.Column<int>(type: "INTEGER", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpulsionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdArcaneSchool = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.IdEnrollment);
                    table.ForeignKey(
                        name: "FK_Enrollments_Arcane_Schools_IdArcaneSchool",
                        column: x => x.IdArcaneSchool,
                        principalTable: "Arcane_Schools",
                        principalColumn: "IdArcaneSchool",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Mages_IdMage",
                        column: x => x.IdMage,
                        principalTable: "Mages",
                        principalColumn: "IdMage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mages_Attuned_Domains",
                columns: table => new
                {
                    IdMage = table.Column<int>(type: "INTEGER", nullable: false),
                    IdArcaneDomain = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mages_Attuned_Domains", x => new { x.IdMage, x.IdArcaneDomain });
                    table.ForeignKey(
                        name: "FK_Mages_Attuned_Domains_Arcane_Domains_IdArcaneDomain",
                        column: x => x.IdArcaneDomain,
                        principalTable: "Arcane_Domains",
                        principalColumn: "IdArcaneDomain",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mages_Attuned_Domains_Mages_IdMage",
                        column: x => x.IdMage,
                        principalTable: "Mages",
                        principalColumn: "IdMage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partnerships",
                columns: table => new
                {
                    IdPartnership = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Goal = table.Column<int>(type: "INTEGER", nullable: false),
                    PartnershipStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PartnershipEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthlyContribution = table.Column<float>(type: "REAL", nullable: false),
                    IdBenefactor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partnerships", x => x.IdPartnership);
                    table.ForeignKey(
                        name: "FK_Partnerships_Benefactors_IdBenefactor",
                        column: x => x.IdBenefactor,
                        principalTable: "Benefactors",
                        principalColumn: "IdBenefactor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partnerships_Mages_IdMage",
                        column: x => x.IdMage,
                        principalTable: "Mages",
                        principalColumn: "IdMage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Noble_Houses",
                columns: table => new
                {
                    IdBenefactor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HouseType = table.Column<int>(type: "INTEGER", nullable: false),
                    BoardOfRulers = table.Column<string>(type: "TEXT", nullable: false),
                    IdKingdom = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefactors", x => x.IdBenefactor);
                    table.ForeignKey(
                        name: "FK_Noble_Houses_Benefactors_IdBenefactor",
                        column: x => x.IdBenefactor,
                        principalTable: "Benefactors",
                        principalColumn: "IdBenefactor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Noble_Houses_Kingdoms_IdKingdom",
                        column: x => x.IdKingdom,
                        principalTable: "Kingdoms",
                        principalColumn: "IdBenefactor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Circle_Spells",
                columns: table => new
                {
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false),
                    CircleRadius = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.IdSpell);
                    table.ForeignKey(
                        name: "FK_Circle_Spells_Spells_IdSpell",
                        column: x => x.IdSpell,
                        principalTable: "Spells",
                        principalColumn: "IdSpell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cone_Spells",
                columns: table => new
                {
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false),
                    ConeSlantHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    ConeRadius = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.IdSpell);
                    table.ForeignKey(
                        name: "FK_Cone_Spells_Spells_IdSpell",
                        column: x => x.IdSpell,
                        principalTable: "Spells",
                        principalColumn: "IdSpell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Line_Spells",
                columns: table => new
                {
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false),
                    LineLength = table.Column<int>(type: "INTEGER", nullable: false),
                    LineWidth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.IdSpell);
                    table.ForeignKey(
                        name: "FK_Line_Spells_Spells_IdSpell",
                        column: x => x.IdSpell,
                        principalTable: "Spells",
                        principalColumn: "IdSpell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projectile_Spells",
                columns: table => new
                {
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectileCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectilePower = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.IdSpell);
                    table.ForeignKey(
                        name: "FK_Projectile_Spells_Spells_IdSpell",
                        column: x => x.IdSpell,
                        principalTable: "Spells",
                        principalColumn: "IdSpell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spells_Knowledge",
                columns: table => new
                {
                    IdMage = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSpell = table.Column<int>(type: "INTEGER", nullable: false),
                    LearningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LevelOfUnderstanding = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells_Knowledge", x => new { x.IdMage, x.IdSpell });
                    table.ForeignKey(
                        name: "FK_Spells_Knowledge_Mages_IdMage",
                        column: x => x.IdMage,
                        principalTable: "Mages",
                        principalColumn: "IdMage",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spells_Knowledge_Spells_IdSpell",
                        column: x => x.IdSpell,
                        principalTable: "Spells",
                        principalColumn: "IdSpell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_IdBenefactor",
                table: "Applications",
                column: "IdBenefactor");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_IdMage",
                table: "Applications",
                column: "IdMage");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_IdArcaneSchool",
                table: "Enrollments",
                column: "IdArcaneSchool");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_IdMage",
                table: "Enrollments",
                column: "IdMage");

            migrationBuilder.CreateIndex(
                name: "IX_Forbidding_Schools_Domains_IdArcaneDomain",
                table: "Forbidding_Schools_Domains",
                column: "IdArcaneDomain");

            migrationBuilder.CreateIndex(
                name: "IX_Mages_IdSoulBoundDomain",
                table: "Mages",
                column: "IdSoulBoundDomain");

            migrationBuilder.CreateIndex(
                name: "IX_Mages_Attuned_Domains_IdArcaneDomain",
                table: "Mages_Attuned_Domains",
                column: "IdArcaneDomain");

            migrationBuilder.CreateIndex(
                name: "IX_Noble_Houses_IdKingdom",
                table: "Noble_Houses",
                column: "IdKingdom");

            migrationBuilder.CreateIndex(
                name: "IX_Partnerships_IdBenefactor",
                table: "Partnerships",
                column: "IdBenefactor");

            migrationBuilder.CreateIndex(
                name: "IX_Partnerships_IdMage",
                table: "Partnerships",
                column: "IdMage");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_IdArcaneDomain",
                table: "Spells",
                column: "IdArcaneDomain");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Name",
                table: "Spells",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Knowledge_IdSpell",
                table: "Spells_Knowledge",
                column: "IdSpell");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_Schools_Domains_IdArcaneDomain",
                table: "Teaching_Schools_Domains",
                column: "IdArcaneDomain");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Circle_Spells");

            migrationBuilder.DropTable(
                name: "Cone_Spells");

            migrationBuilder.DropTable(
                name: "Damaging_Effects");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Forbidding_Schools_Domains");

            migrationBuilder.DropTable(
                name: "Line_Spells");

            migrationBuilder.DropTable(
                name: "Mages_Attuned_Domains");

            migrationBuilder.DropTable(
                name: "Noble_Houses");

            migrationBuilder.DropTable(
                name: "Partnerships");

            migrationBuilder.DropTable(
                name: "Projectile_Spells");

            migrationBuilder.DropTable(
                name: "Restorative_Effects");

            migrationBuilder.DropTable(
                name: "Special_Effects");

            migrationBuilder.DropTable(
                name: "Spells_Knowledge");

            migrationBuilder.DropTable(
                name: "Teaching_Schools_Domains");

            migrationBuilder.DropTable(
                name: "Kingdoms");

            migrationBuilder.DropTable(
                name: "Mages");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Arcane_Schools");

            migrationBuilder.DropTable(
                name: "Benefactors");

            migrationBuilder.DropTable(
                name: "Arcane_Domains");

            migrationBuilder.DropTable(
                name: "Spell_Effects");
        }
    }
}
