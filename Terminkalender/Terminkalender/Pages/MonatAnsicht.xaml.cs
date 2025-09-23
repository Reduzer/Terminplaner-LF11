using System.Windows.Controls;
using Terminkalender.Pages;

namespace Terminkalender
{
	/// <summary>
	/// Interaktionslogik für MonatAnsicht.xaml
	/// </summary>
	public partial class MonatAnsicht : Page
	{
		public MonatAnsicht()
		{
			InitializeComponent();
		}

		private void MontlyCalender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			DateOnly oDate = DateOnly.FromDateTime(MontlyCalender.SelectedDate.Value);

			//Tagesübersicht per factory holen und übergeben
			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowDayInfo(TagesAnsicht.Instance.CreateNewPage(oDate));
		}
	}
}
