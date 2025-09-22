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
        }

        private void SavedClick(object sender, RoutedEventArgs e)
        {
            
            String title = TitleBox.Text;
            DateTime? date = DateTime.Parse(DatePicker.Text);
            //Was ist mit Von und Bis
            //TeilnehmerListe
            String discription = DescriptionBox.Text;

            if (title != String.Empty && date != null) {
                MessageBox.Show("Titel, Wiederholung oder Datum sind null", "Info");
                return;
            }
            //Termin neuerTermin = new Termin(title, date, );

            
        }
    }
}
