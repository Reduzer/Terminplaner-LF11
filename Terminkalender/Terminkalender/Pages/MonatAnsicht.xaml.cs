using System.Windows.Controls;
using Terminkalender.Pages;
using Terminkalender.ViewModel.Interfaces;

namespace Terminkalender
{
	/// <summary>
	/// Interaktionslogik für MonatAnsicht.xaml
	/// </summary>
	public partial class MonatAnsicht : Page
	{
		private IRepositoryHandler oRepoHandler;

		public MonatAnsicht(IRepositoryHandler oRepoHandler)
		{
			InitializeComponent();
		}

		private void MontlyCalender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			DateOnly oDate = DateOnly.FromDateTime(MontlyCalender.SelectedDate.Value);

			//Tagesübersicht per factory holen und übergeben
			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowDayInfo(new TagesAnsicht(oDate, oWindow.oRepoHandler));
		}
	}
}
