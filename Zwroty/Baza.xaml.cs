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
    /// Logika interakcji dla klasy Baza.xaml
    /// </summary>
    public partial class Baza : Window
    {
        Window w1;
        Button b1, b2;
        ListBox lista;
        Poszczegolna_Baza baza;
        StreamWriter writer;
        Window w2;

        public Baza(Window window, ListBox lista, Button b1, Button b2, StreamWriter writer)
        {
            
            this.writer = writer;
            this.lista = lista;
            InitializeComponent();
            w1 = window;
            txtBaza.Content = lista.Items.GetItemAt(lista.SelectedIndex).ToString().Substring(37);

            this.b1 = b1;
            this.b2 = b2;

            baza = App.bazy.getBazy().ElementAt<Poszczegolna_Baza>(lista.SelectedIndex);

            for (int i=0; i < App.bazy.getBazy().ElementAt<Poszczegolna_Baza>(lista.SelectedIndex).getZwroty().Count; i++)
                listBaza.Items.Add(App.bazy.getBazy().ElementAt<Poszczegolna_Baza>(lista.SelectedIndex).getZwroty().ElementAt<Zwrot>(i).konkatenacja());

            baza = App.bazy.getBazy().ElementAt<Poszczegolna_Baza>(lista.SelectedIndex);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            w1.Left = this.Left;
            w1.Top = this.Top;

            w1.Visibility = Visibility.Visible;

            this.Close();

            //this.Content = w1.Content;

            b1.IsEnabled = true;
            b2.IsEnabled = true;
        }

        private void listBaza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUsun2.IsEnabled = true;
        }

        private void btnUsun2_Click(object sender, RoutedEventArgs e)
        {
            btnUsun2.IsEnabled = false;

           App.bazy.getBazy().ElementAt<Poszczegolna_Baza>(lista.SelectedIndex).getZwroty().RemoveAt(listBaza.SelectedIndex);
            listBaza.Items.RemoveAt(listBaza.SelectedIndex);

            FileStream stream2 = new FileStream(baza.getNazwa() + ".dat", FileMode.Truncate);
            StreamWriter writer2 = new StreamWriter(stream2);

            foreach (var item in baza.getZwroty())
            {
                writer2.WriteLine(item.getPL());
                writer2.WriteLine(item.getENG());
            }

            writer2.Close();
            stream2.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //App.bazy.getBazy().ElementAt<Poszczegolna_Baza>(lista.SelectedIndex).getZwroty().RemoveAt(listBaza.SelectedIndex);
            //listBaza.Items.Add();
            DodawanieZwrotu nowyZwrot = new DodawanieZwrotu(listBaza, baza, btnDodawanie, this, writer);

            btnDodawanie.IsEnabled = false;
            nowyZwrot.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            w1.Visibility = Visibility.Visible;
           
        }

        

        private void btnTEST_Click(object sender, RoutedEventArgs e)
        {
            TEST_WEWNETRZNY test = new TEST_WEWNETRZNY();

            test.Left = this.Left + this.Width / 13 + 2;
            test.Top = this.Top + this.Height / 6;

            test.Show();
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            w1.Visibility = Visibility.Visible;
           
        }
    }
}
