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
        public Baza(Window window, ListBox lista)
        {
            InitializeComponent();
            w1 = window;
            txtBaza.Content = lista.Items.GetItemAt(lista.SelectedIndex).ToString().Substring(37);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            w1.Left = this.Left;
            w1.Top = this.Top;

            this.Close();
            
            w1.Visibility = Visibility.Visible;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            w1.Visibility = Visibility.Visible;
        }
    }
}
