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
    /// Logika interakcji dla klasy Baza.xaml
    /// </summary>
    public partial class Baza : Window
    {
        Window w1;
        Button b1, b2;

        public Baza(Window window, ListBox lista, Button b1, Button b2)
        {
            InitializeComponent();
            w1 = window;
            txtBaza.Content = lista.Items.GetItemAt(lista.SelectedIndex).ToString().Substring(37);

            this.b1 = b1;
            this.b2 = b2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            w1.Left = this.Left;
            w1.Top = this.Top;

            this.Close();
            
            w1.Visibility = Visibility.Visible;
            b1.IsEnabled = true;
            b2.IsEnabled = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            w1.Visibility = Visibility.Visible;
        }
    }
}
