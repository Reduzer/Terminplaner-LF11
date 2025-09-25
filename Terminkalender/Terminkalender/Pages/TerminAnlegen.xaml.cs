using Shared;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Terminkalender.Pages;

namespace Terminkalender
{
	public partial class TerminAnlegen : Page
	{
		CultureInfo oCI;
		private string sProvidedDate;

		public TerminAnlegen(string sDateTime)
		{
			InitializeComponent();
			Init();
			oCI = CultureInfo.CurrentUICulture;

			sProvidedDate = sDateTime;
		}

		private void Init()
		{
			TimeOnly oStartTime = TimeOnly.MinValue;

			for (int i = 0; i < 96; i++) {
				StartBox.Items.Add(oStartTime.Add(TimeSpan.FromMinutes(15 * i)));
				EndBox.Items.Add(oStartTime.Add(TimeSpan.FromMinutes(15 * i)));
			}

			for (int i = 0; i < 14; i++) {
				IntervalComboBox.Items.Add(i.ToString());
			}
		}

		private List<string> GetParticipantsFromBox()
		{
			string sBaseString = TeilnehmerBox.Text;

			List<string> vsNames = new List<string>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < sBaseString.Length; i++) {
				if (sBaseString[i] == ' ') {
					continue;
				} else if (sBaseString[i] != ',') {
					sb.Append(sBaseString[i]);
				} else {
					vsNames.Add(sb.ToString());
					sb.Clear();
				}
			}

			vsNames.Add(sb.ToString());
			return vsNames;
		}

		private List<Participant> GetParticipants()
		{
			List<Participant> participants = new List<Participant>();

			foreach (String sTemp in GetParticipantsFromBox()) {
				participants.Add(new Participant(sTemp));
			}

			return participants;
		}

		private void SavedClick(object sender, RoutedEventArgs e)
		{
			Termin neuerTermin;

			try {
				string sTitle = TitleBox.Text;

				string sEndDate = DateTime.Parse(DatePicker.Text).ToString("MM/dd/yyyy");

				DateOnly oEndDate = DateOnly.Parse(sEndDate, CultureInfo.CreateSpecificCulture("en-US"));

				if (oEndDate < DateOnly.Parse(sProvidedDate, CultureInfo.CreateSpecificCulture("en-US"))) {
					throw new Exception("Bitte gebe kein Enddatum an, welches vor dem Startdatum liegt!");
				}

				sEndDate = oEndDate.ToString("MM/dd/yyyy");
				string sStartHour = TimeOnly.Parse(StartBox.Text).ToString("h:mm tt");
				string sEndHour = TimeOnly.Parse(EndBox.Text).ToString("h:mm tt");
				string sLocation = OrtBox.Text;
				short nRepetitionInterval = 0;
				List<Participant> voParticipants = GetParticipants();
				string sDiscription = DescriptionBox.Text;
				bool bIsRepeating = false;

				if (RepeatBox.Text == "Ja") {
					bIsRepeating = true;
					nRepetitionInterval = short.Parse(IntervalComboBox.Text);
				}

				neuerTermin = new Termin(
					sTitle,
					sProvidedDate,
					sEndDate,
					sStartHour,
					sEndHour,
					sLocation,
					voParticipants,
					bIsRepeating,
					nRepetitionInterval,
					sTitle
					);
				
				MainWindow oWindow = (MainWindow)App.Current.MainWindow;
				oWindow.oRepoHandler.Termin().AddTermin(neuerTermin);

				DateOnly oDateTime = DateOnly.Parse(sProvidedDate, CultureInfo.CreateSpecificCulture("en-US"));

				oWindow.ShowDayInfo(new TagesAnsicht(oDateTime, oWindow.oRepoHandler));

			} catch (Exception exception) {
				MessageBox.Show(exception.Message);
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			DateOnly oSelectedDate = DateOnly.Parse(sProvidedDate, CultureInfo.CreateSpecificCulture("en-US"));

			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowDayInfo(new TagesAnsicht(oSelectedDate, oWindow.oRepoHandler));
		}
	}
}
