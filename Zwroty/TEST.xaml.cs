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
using System.Windows.Shapes;

namespace Zwroty
{
    /// <summary>
    /// Logika interakcji dla klasy TEST_WEWNETRZNY.xaml
    /// </summary>
    public partial class TEST : Window
    {
        int i;
        Random random;
        int[] tab;
        Poszczegolna_Baza baza;
        int ile = 0;
        int[] wylosowane;

        public TEST(Poszczegolna_Baza baza)
        {
            InitializeComponent();

            this.baza = baza;

            tab = new int[baza.getZwroty().Count];

            random = new Random();
            i = random.Next(0, baza.getZwroty().Count);

            wylosowane = new int[baza.getZwroty().Count];
            wylosowane[0] = i;
            Losowanie();
            

            zwrotPL.Text = baza.getZwroty().ElementAt(i).getPL();
           
            ile++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Testowanie();
        }

        private void Testowanie()
        {
            sprENG.Text = "";

            if (ile < baza.getZwroty().Count)
            {
                i = wylosowane[ile];

                zwrotPL.Text = baza.getZwroty().ElementAt(i).getPL();

                ile++;
            }

            else
            {

            }
        }

        private bool CzyBylaWylosowana(int iLiczba, int[] tab, int ile)
        {
            int i = 0;
            do
            {
                if(tab[i] == iLiczba )
                    return true;

                i++;
            } while(i<ile );

            return false;
        }


        private void Losowanie()
        {
            int wylosowanych = 1;
            do
            {
                int liczba = random.Next(0, baza.getZwroty().Count);
                if (CzyBylaWylosowana(liczba, wylosowane, wylosowanych) == false)
                {
                    wylosowane[wylosowanych] = liczba;
                    wylosowanych++;
                }
            } while (wylosowanych < baza.getZwroty().Count);
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Testowanie();
            }
        }
    }
}
