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
    /// Logika interakcji dla klasy Nazwa.xaml
    /// </summary>
    public partial class Nazwa : Window
    {
        string nazwa;
        ListBox lista;
        FileStream stream;
        Button edit, test;

        public Nazwa(string nazwa, ListBox lista, FileStream stream, Button edit, Button test)
        {
            InitializeComponent();

            this.nazwa = nazwa;
            this.lista = lista;
            this.stream = stream;
            this.edit = edit;
            this.test = test;

            txtNazwa.Text = nazwa;
            edit.IsEnabled = false;
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            Zmiana_Nazwy();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            Zmiana_Nazwy();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            edit.IsEnabled = true;
        }

        private void Zmiana_Nazwy()
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = txtNazwa.Text;
            SolidColorBrush myBrush = new SolidColorBrush(Colors.FloralWhite);
            item.Background = myBrush;
            item.HorizontalAlignment = HorizontalAlignment.Stretch;

            int currentIndex = lista.SelectedIndex;
            lista.Items.RemoveAt(currentIndex);
            lista.Items.Insert(currentIndex, item);

            if (!nazwa.Equals(txtNazwa.Text))
            {
                File.Copy(nazwa + ".dat", txtNazwa.Text + ".dat");

                File.Delete(nazwa + ".dat");

                App.bazy.getBazy().ElementAt(currentIndex).setNazwa(txtNazwa.Text);
            }

            edit.Visibility = Visibility.Hidden;

            test.IsEnabled = false;

            this.Close();
        }
    }
}
