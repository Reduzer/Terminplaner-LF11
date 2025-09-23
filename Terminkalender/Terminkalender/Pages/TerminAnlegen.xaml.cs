using Shared;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Terminkalender
{
	/// <summary>
	/// Interaktionslogik für TerminAnlegen.xaml
	/// </summary>
	public partial class TerminAnlegen : Page
	{
		private string sName;
		private DateTime oStartDate;
		private DateTime oEndDate;
		private string sLocation;
		private List<Participant> voParticipants;
		private Color oColor;
		private short? nRepititionInterval;
		private string? sNameForRepitition;

		public TerminAnlegen(DateTime oDateTime)
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			DateTime oStartTime = DateTime.Now.Date;

			for (int i = 0; i < 96; i++)
			{
				StartBox.Items.Add(oStartTime.Add(TimeSpan.FromMinutes(15 * i)));
				EndBox.Items.Add(oStartTime.Add(TimeSpan.FromMinutes(15 * i)));
			}
		}

		private List<string> GetParticipantsFromBox()
		{
			string sBaseString = TeilnehmerBox.Text;

			List<string> vsNames = new List<string>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < sBaseString.Length; i++)
			{
				if (sBaseString[i] == ' ')
				{
					continue;
				} else if (sBaseString[i] != ',')
				{
					sb.Append(sBaseString[i]);
				} else
				{
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

			foreach (String sTemp in GetParticipantsFromBox())
			{
				participants.Add(new Participant(sTemp));
			}

			return participants;
		}

		private void SavedClick(object sender, RoutedEventArgs e)
		{
			string sTitle = TitleBox.Text;
			DateTime oEndDate = DateTime.Parse(DatePicker.Text);
			TimeOnly oStartHour = TimeOnly.Parse(StartBox.Text);
			TimeOnly oEndHour = TimeOnly.Parse(EndBox.Text);
			List<Participant> participants = GetParticipants();
			string discription = DescriptionBox.Text;

			if (sTitle == String.Empty && participants.Count == 0)
			{
				MessageBox.Show("Titel, Wiederholung oder Datum sind null", "Info");
				return;
			}
			Termin neuerTermin = new Termin(title, startHour, endHour, participants);


		}
	}
}
