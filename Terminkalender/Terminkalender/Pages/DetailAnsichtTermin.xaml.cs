using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Terminkalender.Pages
{
	public partial class DetailAnsichtTermin : Page
	{
		private Termin m_oTerminToDisplay;

		public DetailAnsichtTermin(Termin oTermin)
		{
			InitializeComponent();

			m_oTerminToDisplay = oTermin;

			FillInfo();

			DeactivateContent();
		}

		private void FillInfo() 
		{
			MainWindow oWindow = (MainWindow)App.Current.MainWindow;

			HeaderForAppointment.Text = m_oTerminToDisplay.sName;
			RepeatBox.SelectedItem = m_oTerminToDisplay.bIsRepeating;
			OrtBox.Text = m_oTerminToDisplay.sLocation;
			StartBox.SelectedValue = m_oTerminToDisplay.sStartTime;
			EndBox.SelectedValue = m_oTerminToDisplay.sEndTime;
			DescriptionBox.Text = m_oTerminToDisplay.sDescription;

			foreach (long nPersonID in m_oTerminToDisplay.vnParticipants) {
				Participant oPerson = oWindow.oRepoHandler.Participant().GetByID(nPersonID);
				if (oPerson != null) {
					TeilnehmerBox.Text += oPerson.sName;
				};
			}
		}

		private void DeactivateContent() 
		{
			Grid oGrid = ContentGrid;

			foreach (UIElement oElement in oGrid.Children) {
				oElement.IsEnabled = false;
			}
		}

		private void ActivateContent() 
		{
			Grid oGrid = ContentGrid;

			foreach (UIElement oElement in oGrid.Children) {
				oElement.IsEnabled = true;
			}
		}

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			DateOnly oDate = DateOnly.Parse(m_oTerminToDisplay.sStartDate, CultureInfo.CreateSpecificCulture("en-US"));
			MainWindow oMainWindow = (MainWindow)App.Current.MainWindow;

			TagesAnsicht oTagesAnsicht = new TagesAnsicht(oDate, oMainWindow.oRepoHandler);
			oMainWindow.ShowDayInfo(oTagesAnsicht);
		}

		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
		{
			ActivateContent();

			ButtonDelete.Visibility = Visibility.Hidden;
			ButtonSave.Visibility = Visibility.Visible;
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult oResult = MessageBox.Show("Möchtest du den Termin wirklich löschen?", "Löschen", MessageBoxButton.YesNo);
			if (oResult == MessageBoxResult.Yes)
			{
				MainWindow oMainWindow = (MainWindow)App.Current.MainWindow;
				oMainWindow.oRepoHandler.Termin().DeleteTermin(m_oTerminToDisplay.nID);
				oMainWindow.ShowDayInfo(new TagesAnsicht(DateOnly.Parse(m_oTerminToDisplay.sStartDate, CultureInfo.CreateSpecificCulture("en-US")), oMainWindow.oRepoHandler));
			}
    }

		private void SaveDataToObject() 
		{
			
		}

		private void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			SaveDataToObject();

			MainWindow oMainWindow = (MainWindow)App.Current.MainWindow;
			oMainWindow.oRepoHandler.Termin().UpdateTermin(m_oTerminToDisplay);

			DeactivateContent();
    }
  }
}
