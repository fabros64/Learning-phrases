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
        public NowaBaza(Button btn1, Button btn2)
        {
            InitializeComponent();
            btnN1 = btn1;
            btnN2 = btn2;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            btnN1.IsEnabled = true;
            btnN2.IsEnabled = true;
        }
    }
}
