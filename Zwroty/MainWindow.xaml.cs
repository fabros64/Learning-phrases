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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
                            
    

    public partial class MainWindow : Window
    {
        //internal static List<Poszczegolna_Baza> Bazy { get => bazy; set => bazy = value; }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnOtworz.IsEnabled = true;
            btnUsun.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NowaBaza nb = new NowaBaza(btnNowa, btnTEST, lista);
            nb.Left = this.Left + this.Width - nb.Width - (this.Width - nb.Width)/2;
            nb.Top = this.Top + this.Height - nb.Height - (this.Height - nb.Height)/2;
            nb.Show();

            btnNowa.IsEnabled = false;
            btnTEST.IsEnabled = false;
            btnOtworz.IsEnabled = false;
            btnUsun.IsEnabled = false;

        }

        private void btnOtworz_Click(object sender, RoutedEventArgs e)
        {
            Baza baza = new Baza(this, lista, btnNowa, btnTEST);
            this.Visibility = Visibility.Collapsed;
            baza.Top = this.Top;
            baza.Left = this.Left;
            baza.Show();
        }

        private void lista_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            App.bazy.getBazy().RemoveAt(lista.SelectedIndex);
            lista.Items.RemoveAt(lista.SelectedIndex);
            btnUsun.IsEnabled = false;
            btnOtworz.IsEnabled = false;
        }
    }
}
