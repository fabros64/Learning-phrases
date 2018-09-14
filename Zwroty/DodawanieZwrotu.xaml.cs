using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logika interakcji dla klasy DodawanieZwrotu.xaml
    /// </summary>
    public partial class DodawanieZwrotu : Window
    {
        ListBox lista;
        Poszczegolna_Baza baza;
        Button dodawanie;
        Window okno;
        StreamWriter writer;

        public DodawanieZwrotu(ListBox lista, Poszczegolna_Baza baza, Button dodawanie, Window okno, StreamWriter writer)
        {
            InitializeComponent();
            warning1.Visibility = Visibility.Collapsed;
            warning2.Visibility = Visibility.Collapsed;

            this.lista = lista;
            this.baza = baza;
            this.dodawanie = dodawanie;
            this.okno = okno;
            this.writer = writer;

            this.Left = okno.Left + 65;
            this.Top = okno.Top + okno.Height / 2;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodawanie();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dodawanie.IsEnabled = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dodawanie.IsEnabled = true;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                Dodawanie();
        }

        private void Dodawanie()
        {
            if (txtPL.Text != "" && txtENG.Text != "")
            {

                warning1.Visibility = Visibility.Hidden;
                warning2.Visibility = Visibility.Hidden;


                ListBoxItem item = new ListBoxItem();
                item.Content = txtPL.Text + " - " + txtENG.Text;
                SolidColorBrush myBrush = new SolidColorBrush(Colors.FloralWhite);
                item.Background = myBrush;
                item.HorizontalAlignment = HorizontalAlignment.Stretch;
                lista.Items.Add(item);

                baza.Dodaj_Zwrot(txtPL.Text, txtENG.Text);

                FileStream stream2 = new FileStream(baza.getNazwa() + ".dat", FileMode.OpenOrCreate);
                StreamWriter writer2 = new StreamWriter(stream2);

                stream2.Position = stream2.Length;

                writer2.WriteLine(txtPL.Text);
                writer2.WriteLine(txtENG.Text);

                //foreach (var item2 in baza.getZwroty())
                //{
                //    writer.WriteLine(item2.getPL());
                //    writer.WriteLine(item2.getENG());
                //}


                writer2.Close();
                stream2.Close();

                this.Close();
            }

            else if (txtPL.Text != "" && txtENG.Text == "")
            {
                warning1.Visibility = Visibility.Hidden;
                warning2.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "" && txtENG.Text != "")
            {
                warning2.Visibility = Visibility.Hidden;
                warning1.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "" && txtENG.Text == "")
            {
                warning1.Visibility = Visibility.Visible;
                warning2.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "")
                warning1.Visibility = Visibility.Visible;
            else if (txtENG.Text == "")
                warning2.Visibility = Visibility.Visible;
        }
    }
}
