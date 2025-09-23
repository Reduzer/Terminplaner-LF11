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

		public void SetPage(Page nextPage)
		{
			NavFrame.Navigate(nextPage);
		}

		public void ShowDayInfo(TagesAnsicht oPageToDisplay)
		{
			FrameTaskView.Navigate(oPageToDisplay);
		}
	}
}