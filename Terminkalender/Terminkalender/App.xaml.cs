using Datenbankanbindung;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Terminkalender.ViewModel;
using Terminkalender.ViewModel.Interfaces;

namespace Terminkalender
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		[STAThread]
		public static void Main(string[] args)
		{
			using IHost oHost = CreateHostBuilder(args).Build();
			oHost.Start();

			Terminkalender.App app = new Terminkalender.App();
		  app.InitializeComponent();

			using TerminVerwalterContext oDbContext = oHost.Services.GetRequiredService<TerminVerwalterContext>();
			oDbContext.Database.EnsureCreated();

			app.MainWindow = oHost.Services.GetRequiredService<MainWindow>();
			app.MainWindow.Visibility = Visibility.Visible;

		  app.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) 
		{
			 return Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostcontext, services) => {
					services.AddDbContext<TerminVerwalterContext>(
						options => 
						{
							options.UseSqlite("Data Source=termine.db");
							options.UseLazyLoadingProxies();
						});
					services.AddSingleton<MainWindow>();
			});	
		}
	}
}
