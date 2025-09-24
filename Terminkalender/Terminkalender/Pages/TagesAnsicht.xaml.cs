using Datenbankanbindung;
using Microsoft.Extensions.Hosting;
using Shared;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Terminkalender.ViewModel.Interfaces;

namespace Terminkalender.Pages
{
	public partial class TagesAnsicht : Page
	{
		private IRepositoryHandler oRepoHandler;
		private ObservableCollection<Termin> oTerminList = new ObservableCollection<Termin>();
		private DateOnly _DateOnly;

		public TagesAnsicht(DateOnly oSelectedDate, IRepositoryHandler oRepoHandler)
		{
			InitializeComponent();

			this.oRepoHandler = oRepoHandler;

			//IEnumerable<Termin> voTermine = oRepoHandler.Termin().GetTermine().Where( e => e.oStartDate == oSelectedDate);
			//if (voTermine.Count() != 0) {
			//	foreach (Termin oTermin in voTermine) {
			//		oTerminList.Add(oTermin);			
			//	}
			//}

			//DGTermine.ItemsSource = oTerminList;

			this._DateOnly = oSelectedDate;

			TxtDate.Text = "Datum: " + _DateOnly.ToString();
		}

		private void CreateTerminButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			DateOnly oSelectedDate = _DateOnly;
			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowCreateTermin(oSelectedDate);
		}
	}
}
