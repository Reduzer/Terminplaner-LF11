using Shared;
using System.Windows;
using System.Windows.Controls;
using Terminkalender.Pages;

namespace Terminkalender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Page oStartingPage = new MonatAnsicht();
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
			MonatAnsicht oMonthlyView = new MonatAnsicht();
			NavFrame.Navigate(oMonthlyView);
		}

		public void ShowCreateTermin(Termin oTermin)
		{
			FrameTaskView.Content = null;

			//FrameTaskView.Navigate();
		}
	}
}