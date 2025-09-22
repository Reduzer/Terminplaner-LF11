using System.Windows;
using System.Windows.Controls;

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
	}
}