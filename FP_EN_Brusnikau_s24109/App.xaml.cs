using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Services.Core_Module;
using FP_EN_Brusnikau_s24109.Services.Miscellaneous;
using FP_EN_Brusnikau_s24109.Services.Partnership_Module;
using FP_EN_Brusnikau_s24109.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;

namespace FP_EN_Brusnikau_s24109
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly ServiceProvider _serviceProvider;

		public App()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

			var serviceCollection = new ServiceCollection();

			serviceCollection.AddDbContext<MageCompendiumContext>(options =>
				options.UseSqlite(connectionString));

			serviceCollection.AddSingleton(provider => new LogInWindow
			{
				DataContext = provider.GetRequiredService<LogInWindowViewModel>()
			});
			serviceCollection.AddSingleton<LogInWindowViewModel>();
			serviceCollection.AddSingleton<LogInViewModel>();
			serviceCollection.AddSingleton<BenefactorLogInViewModel>();
			serviceCollection.AddSingleton<MageLogInViewModel>();
			serviceCollection.AddSingleton<BenefactorApplicationsViewModel>();
			serviceCollection.AddSingleton<BenefactorNegotiationsViewModel>();

			serviceCollection.AddSingleton<INavigationService, NavigationService>();

			serviceCollection.AddSingleton<Func<Type, ViewModel>>(provider => viewModelType => (ViewModel)provider.GetRequiredService(viewModelType));

			serviceCollection.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
			serviceCollection.AddTransient<IBenefactorRepository, BenefactorRepository>();
			serviceCollection.AddTransient<IApplicationRepository, ApplicationRepository>();
			serviceCollection.AddTransient<IPartnershipRepository, PartnershipRepository>();
			serviceCollection.AddTransient<IMageRepository, MageRepository>();

			_serviceProvider = serviceCollection.BuildServiceProvider();

			var seeder = _serviceProvider.GetService<IDatabaseSeeder>();

			var configPath = "D:\\PJATK\\6_sem\\MAS\\MAS\\FP_EN_Brusnikau_s24109\\userConfig.json";
			var config = UserConfig.Load(configPath);

			if (!config.IsDatabaseSeeded)
			{
				seeder.Seed();

				config.IsDatabaseSeeded = true;
				config.Save(configPath);
			}
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var logInWindow = _serviceProvider.GetRequiredService<LogInWindow>();

			logInWindow.Show();

			base.OnStartup(e);
		}
	}
}
