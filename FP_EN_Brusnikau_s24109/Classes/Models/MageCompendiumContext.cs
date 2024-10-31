using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Classes.Models
{
	public partial class MageCompendiumContext : DbContext
    {
        public MageCompendiumContext()
        {
        }

        public MageCompendiumContext(DbContextOptions<MageCompendiumContext> options)
            : base(options)
        {
		}

        public virtual DbSet<ArcaneDomain> ArcaneDomains { get; set; }

        public virtual DbSet<BaseSpell> Spells { get; set; }

		public virtual DbSet<LineSpell> LineSpells { get; set; }

		public virtual DbSet<CircleSpell> CircleSpells { get; set; }

		public virtual DbSet<ConeSpell> ConeSpells { get; set; }

		public virtual DbSet<ProjectileSpell> ProjectileSpells { get; set; }

		public virtual DbSet<SpellEffect> SpellEffects { get; set; }

		public virtual DbSet<DamagingEffect> DamagingEffects { get; set; }

		public virtual DbSet<RestorativeEffect> RestorativeEffects { get; set; }

		public virtual DbSet<SpecialEffect> SpecialEffects { get; set; }

		public virtual DbSet<SpellKnowledge> SpellsKnowledge { get; set; }

		public virtual DbSet<Mage> Mages { get; set; }

		public virtual DbSet<MageAttunedDomain> MagesAttunedDomains { get; set; }

		public virtual DbSet<TeachingSchoolDomain> SchoolsTaughtDomains { get; set; }

		public virtual DbSet<ForbiddingSchoolDomain> SchoolsForbiddenDomains { get; set; }

		public virtual DbSet<ArcaneSchool> ArcaneSchools { get; set; }

		public virtual DbSet<Enrollment> Enrollments { get; set; }

		public virtual DbSet<Application> Applications { get; set; }

		public virtual DbSet<Partnership> Partnerships { get; set; }

		public virtual DbSet<Benefactor> Benefactors { get; set; }

		public virtual DbSet<Kingdom> Kingdoms { get; set; }

		public virtual DbSet<NobleHouse> NobleHouses { get; set; }

		private readonly StreamWriter _logStream = 
			new StreamWriter("D:\\PJATK\\6_sem\\MAS\\MAS\\FP_EN_Brusnikau_s24109\\Data\\sql_log.txt", append: true);

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			if (!optionsBuilder.IsConfigured)
			{
				var configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					.Build();

				optionsBuilder.UseSqlite(configuration.GetConnectionString("Database"), 
					o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
			}

			optionsBuilder.LogTo(_logStream.WriteLine);

			base.OnConfiguring(optionsBuilder);
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
        }

		public override void Dispose()
		{
			base.Dispose();
			_logStream.Dispose();
		}

		public override async ValueTask DisposeAsync()
		{
			await base.DisposeAsync();
			await _logStream.DisposeAsync();
		}
    }
}
