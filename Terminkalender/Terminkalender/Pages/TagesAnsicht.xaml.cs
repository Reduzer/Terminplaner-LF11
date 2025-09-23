using System.Windows.Controls;

namespace Terminkalender.Pages
{
	/// <summary>
	/// Interaction logic for TagesAnsicht.xaml
	/// </summary>
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
			this._DateTime = oSelectedDateTime;
			this._DateOnly = oSelectedDate;
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

	}
}
