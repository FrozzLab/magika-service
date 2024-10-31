﻿// <auto-generated />
using System;
using FP_EN_Brusnikau_s24109.Classes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FP_EN_Brusnikau_s24109.Migrations
{
    [DbContext(typeof(MageCompendiumContext))]
    [Migration("20240831100231_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", b =>
                {
                    b.Property<int>("IdMage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdSoulBoundDomain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPowerLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdMage")
                        .HasName("PK_Mages");

                    b.HasIndex("IdSoulBoundDomain");

                    b.ToTable("Mages", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", b =>
                {
                    b.Property<int>("IdArcaneDomain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuraType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("IdArcaneDomain")
                        .HasName("PK_Arcane_Domains");

                    b.ToTable("Arcane_Domains", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", b =>
                {
                    b.Property<int>("IdSpell")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdArcaneDomain")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdSpellEffect")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PowerLevelCost")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdSpell")
                        .HasName("PK_Spells");

                    b.HasIndex("IdArcaneDomain");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Spells", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.MageAttunedDomain", b =>
                {
                    b.Property<int>("IdMage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdArcaneDomain")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdMage", "IdArcaneDomain")
                        .HasName("PK_Mages_Attuned_Domains");

                    b.HasIndex("IdArcaneDomain");

                    b.ToTable("Mages_Attuned_Domains", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect", b =>
                {
                    b.Property<int>("IdSpellEffect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EffectType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdSpell")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImmuneCreatures")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Potency")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdSpellEffect")
                        .HasName("PK_Spell_Effects");

                    b.ToTable("Spell_Effects", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellKnowledge", b =>
                {
                    b.Property<int>("IdMage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdSpell")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LearningDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LevelOfUnderstanding")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdMage", "IdSpell")
                        .HasName("PK_Spells_Knowledge");

                    b.HasIndex("IdSpell");

                    b.ToTable("Spells_Knowledge", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Application", b =>
                {
                    b.Property<int>("IdApplication")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Goal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBenefactor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NextToRespond")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OfferHistory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("IdApplication")
                        .HasName("PK_Applications");

                    b.HasIndex("IdBenefactor");

                    b.HasIndex("IdMage");

                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor", b =>
                {
                    b.Property<int>("IdBenefactor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EstablishmentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("IdBenefactor")
                        .HasName("PK_Benefactors");

                    b.ToTable("Benefactors", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Partnership", b =>
                {
                    b.Property<int>("IdPartnership")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Goal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdBenefactor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMage")
                        .HasColumnType("INTEGER");

                    b.Property<float>("MonthlyContribution")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("PartnershipEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PartnershipStart")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("IdPartnership")
                        .HasName("PK_Partnerships");

                    b.HasIndex("IdBenefactor");

                    b.HasIndex("IdMage");

                    b.ToTable("Partnerships", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ArcaneSchool", b =>
                {
                    b.Property<int>("IdArcaneSchool")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EnrollmentLengthByDegree")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("IdArcaneSchool")
                        .HasName("PK_Arcane_Schools");

                    b.ToTable("Arcane_Schools", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.Enrollment", b =>
                {
                    b.Property<int>("IdEnrollment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DegreeType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ExpulsionDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("GraduationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdArcaneSchool")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMage")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdEnrollment")
                        .HasName("PK_Enrollments");

                    b.HasIndex("IdArcaneSchool");

                    b.HasIndex("IdMage");

                    b.ToTable("Enrollments", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ForbiddingSchoolDomain", b =>
                {
                    b.Property<int>("IdArcaneSchool")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdArcaneDomain")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdArcaneSchool", "IdArcaneDomain")
                        .HasName("PK_Forbidding_Schools_Domains");

                    b.HasIndex("IdArcaneDomain");

                    b.ToTable("Forbidding_Schools_Domains", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.TeachingSchoolDomain", b =>
                {
                    b.Property<int>("IdArcaneSchool")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdArcaneDomain")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdArcaneSchool", "IdArcaneDomain")
                        .HasName("PK_Teaching_Schools_Domains");

                    b.HasIndex("IdArcaneDomain");

                    b.ToTable("Teaching_Schools_Domains", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.CircleSpell", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell");

                    b.Property<int>("CircleRadius")
                        .HasColumnType("INTEGER");

                    b.ToTable("Circle_Spells", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ConeSpell", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell");

                    b.Property<int>("ConeRadius")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConeSlantHeight")
                        .HasColumnType("INTEGER");

                    b.ToTable("Cone_Spells", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.LineSpell", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell");

                    b.Property<int>("LineLength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineWidth")
                        .HasColumnType("INTEGER");

                    b.ToTable("Line_Spells", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ProjectileSpell", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell");

                    b.Property<int>("ProjectileCount")
                        .HasColumnType("INTEGER");

                    b.Property<float>("ProjectilePower")
                        .HasColumnType("REAL");

                    b.ToTable("Projectile_Spells", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.DamagingEffect", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect");

                    b.Property<int>("DamageTarget")
                        .HasColumnType("INTEGER");

                    b.ToTable("Damaging_Effects", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.RestorativeEffect", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect");

                    b.Property<string>("CuredAilments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Restorative_Effects", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpecialEffect", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect");

                    b.Property<string>("EffectDesctiption")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.ToTable("Special_Effects", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Kingdom", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor");

                    b.Property<string>("SuccessionOrder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Kingdoms", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.NobleHouse", b =>
                {
                    b.HasBaseType("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor");

                    b.Property<string>("BoardOfRulers")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdKingdom")
                        .HasColumnType("INTEGER");

                    b.HasIndex("IdKingdom");

                    b.ToTable("Noble_Houses", (string)null);
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", "SoulBoundDomain")
                        .WithMany("SoulBoundMages")
                        .HasForeignKey("IdSoulBoundDomain");

                    b.Navigation("SoulBoundDomain");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", "ArcaneDomain")
                        .WithMany("Spells")
                        .HasForeignKey("IdArcaneDomain")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect", "Effect")
                        .WithOne("Spell")
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", "IdSpell")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArcaneDomain");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.MageAttunedDomain", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", "ArcaneDomain")
                        .WithMany("AttunedMages")
                        .HasForeignKey("IdArcaneDomain")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", "Mage")
                        .WithMany("AttunedDomains")
                        .HasForeignKey("IdMage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArcaneDomain");

                    b.Navigation("Mage");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellKnowledge", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", "Mage")
                        .WithMany("SpellsKnowledge")
                        .HasForeignKey("IdMage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", "Spell")
                        .WithMany("MagesKnowledge")
                        .HasForeignKey("IdSpell")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mage");

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Application", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor", "Benefactor")
                        .WithMany("Applications")
                        .HasForeignKey("IdBenefactor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", "Mage")
                        .WithMany("Applications")
                        .HasForeignKey("IdMage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefactor");

                    b.Navigation("Mage");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Partnership", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor", "Benefactor")
                        .WithMany("Partnerships")
                        .HasForeignKey("IdBenefactor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", "Mage")
                        .WithMany("Partnerships")
                        .HasForeignKey("IdMage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefactor");

                    b.Navigation("Mage");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.Enrollment", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ArcaneSchool", "ArcaneSchool")
                        .WithMany("Enrollments")
                        .HasForeignKey("IdArcaneSchool")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", "Mage")
                        .WithMany("Enrollments")
                        .HasForeignKey("IdMage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArcaneSchool");

                    b.Navigation("Mage");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ForbiddingSchoolDomain", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", "ArcaneDomain")
                        .WithMany("ForbiddingSchools")
                        .HasForeignKey("IdArcaneDomain")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ArcaneSchool", "ArcaneSchool")
                        .WithMany("ForbiddenDomains")
                        .HasForeignKey("IdArcaneSchool")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ArcaneDomain");

                    b.Navigation("ArcaneSchool");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.TeachingSchoolDomain", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", "ArcaneDomain")
                        .WithMany("TeachingSchools")
                        .HasForeignKey("IdArcaneDomain")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ArcaneSchool", "ArcaneSchool")
                        .WithMany("TaughtDomains")
                        .HasForeignKey("IdArcaneSchool")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArcaneDomain");

                    b.Navigation("ArcaneSchool");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.CircleSpell", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.CircleSpell", "IdSpell")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ConeSpell", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ConeSpell", "IdSpell")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.LineSpell", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.LineSpell", "IdSpell")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ProjectileSpell", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ProjectileSpell", "IdSpell")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.DamagingEffect", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.DamagingEffect", "IdSpellEffect")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.RestorativeEffect", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.RestorativeEffect", "IdSpellEffect")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpecialEffect", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpecialEffect", "IdSpellEffect")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Kingdom", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Kingdom", "IdBenefactor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.NobleHouse", b =>
                {
                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor", null)
                        .WithOne()
                        .HasForeignKey("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.NobleHouse", "IdBenefactor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Kingdom", "Kingdom")
                        .WithMany("NobleHouses")
                        .HasForeignKey("IdKingdom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Core_Module.Mage", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("AttunedDomains");

                    b.Navigation("Enrollments");

                    b.Navigation("Partnerships");

                    b.Navigation("SpellsKnowledge");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.ArcaneDomain", b =>
                {
                    b.Navigation("AttunedMages");

                    b.Navigation("ForbiddingSchools");

                    b.Navigation("SoulBoundMages");

                    b.Navigation("Spells");

                    b.Navigation("TeachingSchools");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.BaseSpell", b =>
                {
                    b.Navigation("MagesKnowledge");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module.SpellEffect", b =>
                {
                    b.Navigation("Spell")
                        .IsRequired();
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Benefactor", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Partnerships");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.School_Module.ArcaneSchool", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("ForbiddenDomains");

                    b.Navigation("TaughtDomains");
                });

            modelBuilder.Entity("FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Kingdom", b =>
                {
                    b.Navigation("NobleHouses");
                });
#pragma warning restore 612, 618
        }
    }
}
