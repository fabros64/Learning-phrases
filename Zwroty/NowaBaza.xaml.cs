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
    /// Logika interakcji dla klasy NowaBaza.xaml
    /// </summary>
    public partial class NowaBaza : Window
    {
        Button btnN1, btnN2;
        ListBox lista2;

        public NowaBaza(Button btn1, Button btn2, ListBox lista)
        {
            InitializeComponent();
            btnN1 = btn1;
            btnN2 = btn2;

            lista2 = lista;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = txtNazwa.Text;
            //Brush pedzel = new Brush();
            //item.Background = "Gray";
            lista2.Items.Add(item);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            btnN1.IsEnabled = true;
            btnN2.IsEnabled = true;
        }
    }
}
