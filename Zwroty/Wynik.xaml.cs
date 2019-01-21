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
        Window window;
        List<int> bledy;
        Poszczegolna_Baza baza;
        List<string> bledySTR;

        Poszczegolna_Baza bazaBledow;

        public Wynik(int ile, int wynik, List<int> bledy, Poszczegolna_Baza baza, List<string> bledySTR, Window window)
        {
            InitializeComponent();
            this.window = window;
            this.bledy = bledy;
            this.baza = baza;
            this.bledySTR = bledySTR;

            lblWynik.Content = "Wynik:  " + wynik + "/" + ile + " pkt ";

            int i = 0;

            bazaBledow = new Poszczegolna_Baza();

            foreach(var item in bledy)
            {
                ListBoxItem item2 = new ListBoxItem();
                item2.Content = baza.getZwroty().ElementAt(item).getPL() + " - " + baza.getZwroty().ElementAt(item).getENG();
                SolidColorBrush myBrush = new SolidColorBrush(Colors.LightCyan);
                item2.Background = myBrush;
                item2.HorizontalAlignment = HorizontalAlignment.Stretch;

                listWynik.Items.Add(item2);
                bazaBledow.Dodaj_Zwrot(baza.getZwroty().ElementAt(item).getPL(), baza.getZwroty().ElementAt(item).getENG());

                ListBoxItem item3 = new ListBoxItem();
                item3.Content = bledySTR.ElementAt(i++);
                SolidColorBrush myBrush2 = new SolidColorBrush(Colors.LightCyan);
                item3.Background = myBrush2;
                item3.HorizontalAlignment = HorizontalAlignment.Stretch;

                listBłąd.Items.Add(item3);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window.Close();
        }

        private void btnTestZBledow_Click(object sender, RoutedEventArgs e)
        {
            if (bledy.Count != 0)
            {
                TEST test = new TEST(bazaBledow, window);

                test.Left = window.Left + this.Width / 13 + 2;
                test.Top = window.Top + this.Height / 6;

                test.Show();

                window.Visibility = Visibility.Collapsed;
            }

            else MessageBox.Show("Brak błędów");
        }
    }
}
