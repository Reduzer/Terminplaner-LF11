using System.Windows;
using System.Windows.Controls;

namespace Terminkalender.Pages
{
	public partial class TagesAnsicht : Page
	{
		private static TagesAnsicht _instance;

		private DateTime _DateTime;
		private DateOnly _DateOnly;

		private TagesAnsicht()
		{
			InitializeComponent();
		}

		private TagesAnsicht(DateTime oSelectedDateTime, DateOnly oSelectedDate) 
		{
			InitializeComponent();

			this._DateTime = oSelectedDateTime;
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

		public TagesAnsicht CreateNewPage(DateTime dateTime, DateOnly oDate) {
			return new TagesAnsicht(dateTime, oDate);
		}

		private void CreateTerminButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			
		}
	}
}
