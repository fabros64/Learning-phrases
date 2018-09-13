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
        Window window;
        string[] wynikowe;
        List<int> bledy;
        List<string> bledySTR;

        public TEST(Poszczegolna_Baza baza, Window window)
        {
            InitializeComponent();

            this.baza = baza;
            this.window = window;

            tab = new int[baza.getZwroty().Count];
            wynikowe = new string[baza.getZwroty().Count];

            random = new Random();
            i = random.Next(0, baza.getZwroty().Count);

            wylosowane = new int[baza.getZwroty().Count];
            wylosowane[0] = i;

            Losowanie();
            

            zwrotPL.Text = baza.getZwroty().ElementAt(i).getPL();
           
            ile++;
            bledy = new List<int>();
            bledySTR = new List<string>();

            CountPytania.Content = "Pytanie " + 1 + " z " + baza.getZwroty().Count;
        }

        public TEST(Window window)
        {
            InitializeComponent();
            this.window = window;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Testowanie();
        }

        private void Testowanie()
        {
            int pkt = 0;
            wynikowe[i] = sprENG.Text;

            CountPytania.Content = "Pytanie " + (ile+1) + " z " + baza.getZwroty().Count;

            //if (baza.getZwroty().ElementAt(i).getENG().ToUpper().Equals(wynikowe[i].ToUpper()))
            //    pkt++;
            //else
            //{
            //    bledy.Add(i);
            //}

            if (ile < baza.getZwroty().Count)
            {
                i = wylosowane[ile];

                zwrotPL.Text = baza.getZwroty().ElementAt(i).getPL();

                ile++;

                wynikowe[i] = sprENG.Text;
                sprENG.Text = "";
            }

            else
            {
                

                for(int j=0; j < baza.getZwroty().Count; j++)
                {
                    if (baza.getZwroty().ElementAt(j).getENG().ToUpper().Equals(wynikowe[j].ToUpper()))
                        pkt++;
                    else
                    {
                        bledy.Add(j);
                        bledySTR.Add(wynikowe[j]);
                    }
                }

                Wynik wynik = new Wynik(baza.getZwroty().Count, pkt, bledy, baza, bledySTR, this);
                this.Content = wynik.Content;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            window.Visibility = Visibility.Visible;
        }
    }
}
