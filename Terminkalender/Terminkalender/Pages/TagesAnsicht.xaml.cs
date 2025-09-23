using System.Windows;
using System.Windows.Controls;

namespace Terminkalender.Pages
{
	public partial class TagesAnsicht : Page
	{
		private static TagesAnsicht _instance;
		private DateOnly _DateOnly;

		private TagesAnsicht()
		{
			InitializeComponent();
		}

		private TagesAnsicht(DateOnly oSelectedDate) 
		{
			InitializeComponent();

			this._DateOnly = oSelectedDate;

			TxtDate.Text = "Datum: " + _DateOnly.ToString();
		}

		public static TagesAnsicht Instance 
		{
			get {
				if (_instance == null) {
					_instance = new TagesAnsicht();
				}

				return _instance;
			}
		}

		public TagesAnsicht CreateNewPage(DateOnly oDate) {
			return new TagesAnsicht(oDate);
		}

		private void CreateTerminButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			DateOnly oSelectedDate = _DateOnly;
			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowCreateTermin(oSelectedDate);
		}
	}
}
