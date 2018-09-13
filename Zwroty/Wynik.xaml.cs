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

namespace Zwroty
{
    /// <summary>
    /// Logika interakcji dla klasy Wynik.xaml
    /// </summary>
    public partial class Wynik : Page
    {
        public Wynik(int ile, int wynik, List<int> bledy, Poszczegolna_Baza baza)
        {
            InitializeComponent();

            lblWynik.Content = "Wynik:  " + wynik + "/" + ile + " pkt ";


        }
    }
}
