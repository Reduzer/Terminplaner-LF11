using Datenbankanbindung;
using System.Windows;
using System.Windows.Controls;
using Terminkalender.Pages;
using Terminkalender.ViewModel.Interfaces;

namespace Terminkalender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public IRepositoryHandler oRepoHandler;

		public MainWindow(TerminVerwalterContext oContext)
		{
			oRepoHandler = new RepositoryHandler(oContext);

			InitializeComponent();
			Page oStartingPage = new MonatAnsicht(oRepoHandler);
			NavFrame.Navigate(oStartingPage);
		}

		public void ShowDayInfo(TagesAnsicht oPageToDisplay)
		{
			FrameTaskView.Content = null;

			FrameTaskView.Navigate(oPageToDisplay);
		}

		private void ShowWeekly_Click(object sender, RoutedEventArgs e)
		{
			WochenAnsicht oWeeklyView = new WochenAnsicht();
			NavFrame.Navigate(oWeeklyView);
		}

		private void ShowMonthly_Click(object sender, RoutedEventArgs e)
		{
			MonatAnsicht oMonthlyView = new MonatAnsicht(oRepoHandler);
			NavFrame.Navigate(oMonthlyView);
		}

		public void ShowCreateTermin(DateOnly oDate)
		{
			FrameTaskView.Content = null;

			FrameTaskView.Navigate(new TerminAnlegen(oDate));
		}
	}
}