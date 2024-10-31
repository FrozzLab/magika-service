using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using System.Collections.Generic;
using System;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.DTOs.Partnership_Module;

namespace FP_EN_Brusnikau_s24109.Services.Miscellaneous
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly MageCompendiumContext _context;

        public DatabaseSeeder(MageCompendiumContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            ArcaneDomain
                ad1 = new ArcaneDomain
                {
                    IdArcaneDomain = -1,
                    Name = "Angelica",
                    AuraType = AuraType.Holy
                },
                ad2 = new ArcaneDomain
                {
                    IdArcaneDomain = -2,
                    Name = "Ikoru",
                    AuraType = AuraType.Neutral
                },
                ad3 = new ArcaneDomain
                {
                    IdArcaneDomain = -3,
                    Name = "Flamos",
                    AuraType = AuraType.Unholy
                };

            _context.ArcaneDomains.AddRange(ad1, ad2, ad3);

            _context.SaveChanges();

            _context.DamagingEffects.AddRange
            (
                new DamagingEffect
                {
                    IdSpellEffect = -3,
                    ImmuneCreatures = new List<CreatureType> { CreatureType.Apparition },
                    Potency = 5,
                    DamageTarget = DamageTarget.Body
                },
                new DamagingEffect
                {
                    IdSpellEffect = -4,
                    ImmuneCreatures = new List<CreatureType> { CreatureType.Undead },
                    Potency = 10,
                    DamageTarget = DamageTarget.Combined
                }
            );

            _context.RestorativeEffects.AddRange
            (
                new RestorativeEffect
                {
                    IdSpellEffect = -1,
                    ImmuneCreatures = new List<CreatureType> { CreatureType.Animated },
                    Potency = 5,
                    CuredAilments = new List<AilmentType> { AilmentType.Curse, AilmentType.Mental, AilmentType.Disease }
                },
                new RestorativeEffect
                {
                    IdSpellEffect = -2,
                    ImmuneCreatures = new List<CreatureType> { CreatureType.Animated },
                    Potency = 7,
                    CuredAilments = new List<AilmentType> { AilmentType.Bodily, AilmentType.Disease }
                }
            );

            _context.SpecialEffects.Add
            (
                new SpecialEffect
                {
                    IdSpellEffect = -5,
                    ImmuneCreatures = new List<CreatureType> { },
                    Potency = 10,
                    EffectDesctiption = "Affected creature cannot move their body until the spell weakens."
                }
            );

			_context.ProjectileSpells.AddRange
            (
                new ProjectileSpell
                {
                    IdSpell = -1,
                    IdArcaneDomain = -1,
					IdSpellEffect = -1,
					Name = "Blessing from Above",
                    PowerLevelCost = 2,
                    ProjectileCount = 3,
                    ProjectilePower = 5
                },
                new ProjectileSpell
                {
                    IdSpell = -3,
                    IdArcaneDomain = -2,
					IdSpellEffect = -3,
					Name = "Roots of Nature",
                    PowerLevelCost = 3,
                    ProjectileCount = 10,
                    ProjectilePower = 1
                }
            );

            _context.LineSpells.Add
            (
                new LineSpell
                {
                    IdSpell = -2,
                    IdArcaneDomain = -1,
					IdSpellEffect = -2,
					Name = "Holy Healing",
                    PowerLevelCost = 1,
                    LineLength = 10,
                    LineWidth = 2
                }
            );

            _context.CircleSpells.Add
            (
                new CircleSpell
                {
                    IdSpell = -5,
                    IdArcaneDomain = -3,
					IdSpellEffect = -5,
					Name = "Entrapment",
                    PowerLevelCost = 7,
                    CircleRadius = 5
                }
            );

            _context.ConeSpells.Add
            (
                new ConeSpell
                {
                    IdSpell = -4,
                    IdArcaneDomain = -2,
					IdSpellEffect = -4,
					Name = "Fiery Death",
                    PowerLevelCost = 5,
                    ConeSlantHeight = 50,
                    ConeRadius = 5
                }
            );

            _context.SaveChanges();

            Mage
                m1 = new Mage
                {
                    IdMage = -1,
                    Name = "Josephina Lerdovio",
                    TotalPowerLevel = 1000,
                    BirthDate = new DateTime(2000, 10, 12)
                },
                m2 = new Mage
                {
                    IdMage = -2,
                    Name = "Bobert Schmobert",
                    TotalPowerLevel = 700,
                    BirthDate = new DateTime(1998, 5, 20)
                },
                m3 = new Mage
                {
                    IdMage = -3,
                    Name = "Lindo",
                    TotalPowerLevel = 7000,
                    BirthDate = new DateTime(1985, 11, 6)
                },
                m4 = new Mage
                {
                    IdMage = -4,
                    Name = "Sergius",
                    TotalPowerLevel = 100,
                    BirthDate = new DateTime(2004, 3, 1)
                },
                m5 = new Mage
                {
                    IdMage = -5,
                    Name = "Zmundius Vesuvius",
                    TotalPowerLevel = 5000,
                    BirthDate = new DateTime(1943, 1, 26)
                };

            _context.MagesAttunedDomains.AddRange(
                new MageAttunedDomain
                {
                    Mage = m1,
                    ArcaneDomain = ad1
                },
                new MageAttunedDomain
                {
                    Mage = m1,
                    ArcaneDomain = ad3
                },
                new MageAttunedDomain
                {
                    Mage = m2,
                    ArcaneDomain = ad1
                },
                new MageAttunedDomain
                {
                    Mage = m3,
                    ArcaneDomain = ad1
                },
                new MageAttunedDomain
                {
                    Mage = m3,
                    ArcaneDomain = ad2
                },
                new MageAttunedDomain
                {
                    Mage = m4,
                    ArcaneDomain = ad3
                },
                new MageAttunedDomain
                {
                    Mage = m5,
                    ArcaneDomain = ad2
                },
                new MageAttunedDomain
                {
                    Mage = m5,
                    ArcaneDomain = ad3
                }
            );

            _context.Mages.AddRange(m1, m2, m3, m4, m5);

            _context.SaveChanges();

            _context.AddRange
            (
                new SpellKnowledge
                {
                    IdMage = -1,
                    IdSpell = -1,
                    LevelOfUnderstanding = LevelOfUnderstanding.Average
                },
                new SpellKnowledge
                {
                    IdMage = -1,
                    IdSpell = -4,
                    LevelOfUnderstanding = LevelOfUnderstanding.Novice
                },
                new SpellKnowledge
                {
                    IdMage = -1,
                    IdSpell = -5,
                    LevelOfUnderstanding = LevelOfUnderstanding.Proficient
                },
                new SpellKnowledge
                {
                    IdMage = -2,
                    IdSpell = -1,
                    LevelOfUnderstanding = LevelOfUnderstanding.Novice
                },
                new SpellKnowledge
                {
                    IdMage = -2,
                    IdSpell = -2,
                    LevelOfUnderstanding = LevelOfUnderstanding.Average
                },
                new SpellKnowledge
                {
                    IdMage = -3,
                    IdSpell = -1,
                    LevelOfUnderstanding = LevelOfUnderstanding.Average
                },
                new SpellKnowledge
                {
                    IdMage = -3,
                    IdSpell = -3,
                    LevelOfUnderstanding = LevelOfUnderstanding.Proficient
                },
                new SpellKnowledge
                {
                    IdMage = -4,
                    IdSpell = -4,
                    LevelOfUnderstanding = LevelOfUnderstanding.Proficient
                },
                new SpellKnowledge
                {
                    IdMage = -4,
                    IdSpell = -5,
                    LevelOfUnderstanding = LevelOfUnderstanding.Novice
                },
                new SpellKnowledge
                {
                    IdMage = -5,
                    IdSpell = -3,
                    LevelOfUnderstanding = LevelOfUnderstanding.Average
                },
                new SpellKnowledge
                {
                    IdMage = -5,
                    IdSpell = -4,
                    LevelOfUnderstanding = LevelOfUnderstanding.Proficient
                },
                new SpellKnowledge
                {
                    IdMage = -5,
                    IdSpell = -5,
                    LevelOfUnderstanding = LevelOfUnderstanding.Proficient
                }
            );

            _context.SaveChanges();

            ArcaneSchool
                asc1 = new ArcaneSchool
                {
                    IdArcaneSchool = -1,
                    Name = "The School of Everything",
                    EnrollmentLengthByDegree = new Dictionary<DegreeType, TimeSpan>()
                    {
                        [DegreeType.Apprentice] = new TimeSpan(1000, 0, 0),
                        [DegreeType.Magistrate] = new TimeSpan(1200, 0, 0),
                        [DegreeType.Archmagistrate] = new TimeSpan(1600, 0, 0)
                    },
                    FoundationDate = new DateTime(1071, 10, 1)
                },
                asc2 = new ArcaneSchool
                {
                    IdArcaneSchool = -2,
                    Name = "University of Demonic Arts",
                    EnrollmentLengthByDegree = new Dictionary<DegreeType, TimeSpan>()
                    {
                        [DegreeType.Archmagistrate] = new TimeSpan(2200, 0, 0)
                    },
                    FoundationDate = new DateTime(651, 6, 18)
                };

            _context.SchoolsTaughtDomains.AddRange
            (
                new TeachingSchoolDomain
                {
                    ArcaneSchool = asc1,
                    ArcaneDomain = ad1
                },
                new TeachingSchoolDomain
                {
                    ArcaneSchool = asc1,
                    ArcaneDomain = ad2
                },
                new TeachingSchoolDomain
                {
                    ArcaneSchool = asc1,
                    ArcaneDomain = ad3
                },
                new TeachingSchoolDomain
                {
                    ArcaneSchool = asc2,
                    ArcaneDomain = ad3
                }
            );

            _context.SchoolsForbiddenDomains.AddRange
            (
                new ForbiddingSchoolDomain
                {
                    ArcaneSchool = asc2,
                    ArcaneDomain = ad1
                },
                new ForbiddingSchoolDomain
                {
                    ArcaneSchool = asc2,
                    ArcaneDomain = ad2
                }
            );

            _context.AddRange(asc1, asc2);

            _context.SaveChanges();

            _context.Enrollments.AddRange
            (
                new Enrollment
                {
                    IdMage = -1,
                    IdArcaneSchool = -1,
                    ArcaneSchool = asc1,
                    DegreeType = DegreeType.Apprentice
                },
                new Enrollment
                {
                    IdMage = -3,
                    IdArcaneSchool = -1,
                    ArcaneSchool = asc1,
                    DegreeType = DegreeType.Apprentice,
                },
                new Enrollment
                {
                    IdMage = -5,
                    IdArcaneSchool = -2,
                    ArcaneSchool = asc2,
                    DegreeType = DegreeType.Archmagistrate
                }
            );

            _context.SaveChanges();

            Kingdom
                k1 = new Kingdom
                {
                    IdBenefactor = -1,
                    Name = "The Kingdom of Jordania",
                    EstablishmentDate = new DateTime(760, 9, 14),
                    SuccessionOrder = new List<string>
                    {
                        "Pedro Marticelli",
                        "Vanessa Van Droght",
                        "Silesio Ventuccio"
                    }
                },
                k2 = new Kingdom
                {
                    IdBenefactor = -2,
                    Name = "Elysium",
                    EstablishmentDate = new DateTime(1253, 2, 3),
                    SuccessionOrder = new List<string>
                    {
                        "Follosdium",
                        "Lakh'D'Mardkrummh",
                        "Girrdanu-Ogtradd",
                        "Pragroli"
                    }
                };

            _context.AddRange(k1, k2);

            _context.SaveChanges();

            NobleHouse
                    nh1 = new NobleHouse
                    {
                        IdBenefactor = -3,
                        IdKingdom = -1,
                        Name = "Muesli Emporium of Arts",
                        EstablishmentDate = new DateTime(679, 11, 23),
                        HouseType = HouseType.Arts,
                        BoardOfRulers = new List<string>
                        {
                            "Ricardo Muesli",
                            "Flidlina Muesli",
                            "Marchi Muesli",
                            "Rokko Muesli"
                        }
                    },
                    nh2 = new NobleHouse
                    {
                        IdBenefactor = -4,
                        IdKingdom = -1,
                        Name = "The Soldiers of the Kingdom",
                        EstablishmentDate = new DateTime(1498, 6, 3),
                        HouseType = HouseType.Military,
                        BoardOfRulers = new List<string>
                        {
                            "Frederick of Jordania",
                            "Veronica Gradias",
                            "Lyra Khokkh'radd"
                        }
                    },
                    nh3 = new NobleHouse
                    {
                        IdBenefactor = -5,
                        IdKingdom = -2,
                        Name = "The Lost Caravans",
                        EstablishmentDate = new DateTime(501, 12, 14),
                        HouseType = HouseType.Commerce,
                        BoardOfRulers = new List<string>
                        {
                            "Vidraffim Gruddhum",
                            "Quorrlam Safradd",
                            "Liprokka-Prommd",
                            "Vofdroggam",
                            "Errsidi Qurmuvviud"
                        }
                    };

            _context.AddRange(nh1, nh2, nh3);

            _context.SaveChanges();

            var app1 = m1.SendOutApplicationForPartnership
            (
                new ApplicationDTO
                (
                    m1,
					k1,
				    "Look into magical treatments for non-standard diseases",
				    PartnershipGoal.Research,
					"The initiative aims to investigate and develop magical remedies for diseases " +
                    "that are atypical or resistant to conventional medical approaches. By combining " +
                    "arcane knowledge with medical research, the project seeks to discover new " +
                    "treatments or cures for these rare and challenging conditions. This research " +
                    "could involve analyzing magical properties that influence biological processes, " +
                    "creating enchanted potions or spells, and testing their efficacy in treating " +
                    "non-standard ailments. The objective is to expand the boundaries of medical science " +
                    "with innovative magical solutions, potentially offering new hope for patients " +
                    "suffering from otherwise untreatable diseases.",
					40
				)
            );
            var app2 = m1.SendOutApplicationForPartnership
            (
				new ApplicationDTO
				(
					m1,
				    nh3,
				    "Utilizing dark magicks to improve trading route security",
				    PartnershipGoal.Research,
					"The initiative explores how dark magics can be applied to fortify and safeguard " +
                    "trading routes. By employing protective spells and curses, the goal is to deter " +
                    "or neutralize threats such as banditry, espionage, and magical interference. These " +
                    "dark magics could be used to create barriers, conceal routes, or curse those who " +
                    "attempt to disrupt the trade flow. This approach aims to ensure safer and more reliable " +
                    "transportation of goods, ultimately boosting trade efficiency and reducing losses.",
   					80
				)
            );
            var app3 = m2.SendOutApplicationForPartnership
            (
				new ApplicationDTO
				(
					m2,
				    nh2,
				    "Application of holy magic on the battlefield",
				    PartnershipGoal.Warfare,
					"The initiative seeks to employ holy magic as a potent force in military engagements. " +
                    "By invoking divine blessings and spells, the project aims to enhance the effectiveness of " +
                    "troops, providing them with protection from harm, healing injuries, and even turning the " +
                    "tide of battle with miraculous interventions. Holy magic could also be used to weaken or " +
                    "dispel dark forces, making it an invaluable asset against opponents who rely on malevolent " +
                    "powers. This approach offers a way to infuse spirituality into warfare, combining faith with " +
                    "strategy to achieve victory in a just and righteous manner.",
					115
				)
            );
            var app4 = m3.SendOutApplicationForPartnership
            (
				new ApplicationDTO
				(
					m3,
				    nh1,
				    "Nature and Art: Never-seen-before works of any design",
				    PartnershipGoal.Service,
					"This proposal aims to merge natural elements with artistic design to create unique, " +
                    "never-before-seen works that captivate and inspire. The focus is on providing a service " +
                    "that blends creativity with nature to produce extraordinary designs.",

					290
				)
            );
            var app5 = m4.SendOutApplicationForPartnership
            (
				new ApplicationDTO
				(
					m4,
				    k2,
				    "Usage of Demonics to improve worker efficiency",
				    PartnershipGoal.Manufacture,
					"The initiative suggests summoning and binding demons to assist in manufacturing tasks, leveraging " +
                    "their immense strength and tireless nature to boost output. These entities could take on the most " +
                    "demanding and repetitive tasks, ensuring a more efficient production line with minimal human intervention. " +
                    "The primary focus is on creating a controlled environment where these forces can be safely utilized to " +
                    "maximize industrial efficiency, reducing costs and increasing overall productivity.",
					135
				)
            );
            var app6 = m4.SendOutApplicationForPartnership
            (
				new ApplicationDTO
				(
					m4,
				    nh2,
				    "Demonics and the Art of Destruction",
				    PartnershipGoal.Warfare,
                    "The proposal revolves around the unconventional yet strategic idea of leveraging dark forces to gain a " +
                    "significant edge in warfare.The central question posed—\"What if we just summon demons to fight for us?\"—" +
                    "challenges traditional military strategies by exploring the potential of summoning and controlling " +
                    "demonic entities to serve as combatants in battle.",
					470
				)
            );
            var app7 = m5.SendOutApplicationForPartnership
            (
				new ApplicationDTO
				(
					m5,
				    k1,
				    "Research into prevention of demonic corruption through forcibly-induced insertion of natural purificators",
				    PartnershipGoal.Research,
                    "Preliminary research suggests that demonic corruption can be partially or fully influenced " +
                    "and potentially controlled using natural-born purificators, such as those found in the mountains of" +
                    "Karagada. These purificators seemingly connect to a kind of corruption \"hivemind\", and possess " +
                    "decision-making power upon doing so. Financing this reseach would provide the necessary grounds to " +
                    "conduct further practical experiments.",
				    6540
				)
            );

            app2.MakeOffer(70, OfferingSide.Benefactor);
            app2.MakeOffer(75, OfferingSide.Applicant);
            app2.CancelNegotiations();

            app3.MakeOffer(80, OfferingSide.Benefactor);
            app3.MakeOffer(115, OfferingSide.Applicant);
            app3.MakeOffer(95, OfferingSide.Benefactor);
            app3.MakeOffer(115, OfferingSide.Applicant);
            var p1 = app3.ConcludeNegotiations();

            app4.MakeOffer(240, OfferingSide.Benefactor);
            app4.MakeOffer(260, OfferingSide.Applicant);
            app4.MakeOffer(250, OfferingSide.Benefactor);

            app6.MakeOffer(450, OfferingSide.Benefactor);
            var p2 = app6.ConcludeNegotiations();

            app7.MakeOffer(5700, OfferingSide.Benefactor);
            app7.MakeOffer(6600, OfferingSide.Applicant);
            app7.MakeOffer(5840, OfferingSide.Benefactor);
            app7.MakeOffer(6700, OfferingSide.Applicant);
            app7.MakeOffer(6100, OfferingSide.Benefactor);
            app7.MakeOffer(6800, OfferingSide.Applicant);
            app7.MakeOffer(6400, OfferingSide.Benefactor);
            app7.MakeOffer(6900, OfferingSide.Applicant);
            app7.MakeOffer(3200, OfferingSide.Benefactor);
            app7.MakeOffer(7000, OfferingSide.Applicant);
            app7.MakeOffer(6540, OfferingSide.Benefactor);
            app7.MakeOffer(7100, OfferingSide.Applicant);

            _context.AddRange(app1, app2, app3, app4, app5, app6, app7);

            _context.SaveChanges();

            _context.AddRange(p1, p2);

            _context.SaveChanges();
        }
    }
}
