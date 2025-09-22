using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Terminkalender
{
    /// <summary>
    /// Interaktionslogik für TerminAnlegen.xaml
    /// </summary>
    public partial class TerminAnlegen : Page
    {
        public TerminAnlegen()
        {
            InitializeComponent();
			Init();
			}
		private void Init(){
			DateTime oStartTime = DateTime.Now.Date;

			for(int i = 0; i < 96; i++){
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
                }
                else if (sBaseString[i] != ',')
                {
                    sb.Append(sBaseString[i]);
                }
                else
                {
                    vsNames.Add(sb.ToString());
                    sb.Clear();
                }
            }

            vsNames.Add(sb.ToString());
            return vsNames;
        }

        private void SavedClick(object sender, RoutedEventArgs e)
        {
            
            String title = TitleBox.Text;
            DateTime date = DateTime.Parse(DatePicker.Text);
            DateTime startHour = DateTime.Parse(StartBox.Text);
            DateTime endHour = DateTime.Parse(EndBox.Text);
            List<Participant> participants = new List<Participant>();

            foreach(String sTemp in GetParticipantsFromBox()) {
                participants.Add(new Participant(sTemp));
            }

            String discription = DescriptionBox.Text;

            if (title == String.Empty && participants.Count == 0) {
                MessageBox.Show("Titel, Wiederholung oder Datum sind null", "Info");
                return;
            }
            Termin neuerTermin = new Termin(title, startHour, endHour, participants);


        }
    }
}
