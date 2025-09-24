using Shared;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Terminkalender.Pages;

namespace Terminkalender
{
	public partial class TerminAnlegen : Page
	{
		private DateOnly oProvidedDate;

		public TerminAnlegen(DateOnly oDateTime)
		{
			InitializeComponent();
			Init();

			oProvidedDate = oDateTime;
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
				DateOnly oEndDate = DateOnly.Parse(DatePicker.Text);
				TimeOnly oStartHour = TimeOnly.Parse(StartBox.Text);
				TimeOnly oEndHour = TimeOnly.Parse(EndBox.Text);
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
					oProvidedDate,
					oEndDate,
					oStartHour,
					oEndHour,
					sLocation,
					voParticipants,
					bIsRepeating,
					nRepetitionInterval,
					sTitle
					);
				
				MainWindow oWindow = (MainWindow)App.Current.MainWindow;
				oWindow.oRepoHandler.Termin().AddTermin(neuerTermin);
				oWindow.ShowDayInfo(new TagesAnsicht(oProvidedDate, oWindow.oRepoHandler));

			} catch (Exception exception) {
				MessageBox.Show(exception.Message);
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			DateOnly oSelectedDate = oProvidedDate;

			MainWindow oWindow = (MainWindow)App.Current.MainWindow;
			oWindow.ShowDayInfo(new TagesAnsicht(oSelectedDate, oWindow.oRepoHandler));
		}
	}
}
