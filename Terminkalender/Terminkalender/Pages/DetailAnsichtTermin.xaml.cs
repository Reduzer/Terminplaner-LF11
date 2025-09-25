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
	/// <summary>
	/// Interaction logic for DetailAnsichtTermin.xaml
	/// </summary>
	public partial class DetailAnsichtTermin : Page
	{
		private Termin m_oTerminToDisplay;

		public DetailAnsichtTermin(Termin oTermin)
		{
			InitializeComponent();

			m_oTerminToDisplay = oTermin;

			FillInfo();
		}

		private void FillInfo() 
		{
			HeaderForAppointment.Text = m_oTerminToDisplay.sName;
			DatePickerVon.Text = m_oTerminToDisplay.sStartDate;
		}

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			DateOnly oDate = DateOnly.Parse(m_oTerminToDisplay.sStartDate, CultureInfo.CreateSpecificCulture("en-US"));

		}

		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
