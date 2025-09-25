using Datenbankanbindung;
using Microsoft.Extensions.Hosting;
using Shared;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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

			this._DateOnly = oSelectedDate;

			TxtDate.Text = "Datum: " + _DateOnly.ToString();

			Init();

			DGTermine.ItemsSource = oTerminList;
		}

		private void Init()
		{
			IEnumerable<Termin> voTermine = oRepoHandler.Termin().GetTermine();

			if (voTermine.Count() != 0) {
				foreach (Termin oTermin in voTermine) {
					if ((DateOnly.Parse(oTermin.sStartDate, CultureInfo.CreateSpecificCulture("en-US")) <= _DateOnly) && DateOnly.Parse(oTermin.sEndDate, CultureInfo.CreateSpecificCulture("en-US")) >= _DateOnly) {
						oTerminList.Add(oTermin);
					}
				}
			}
		}

		private void CreateTerminButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			DateOnly oSelectedDate = _DateOnly;
			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowCreateTermin(oSelectedDate);
		}

		private void ShowDetailedView_Click(object sender, RoutedEventArgs e)
		{
			Termin Caller = (Termin)DGTermine.CurrentItem;

			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowDetailedAppointmentView(Caller);
    }
  }
}
