﻿using System;
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

            btnZatwierdz.IsEnabled = false;
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = txtNazwa.Text;
            SolidColorBrush myBrush = new SolidColorBrush(Colors.FloralWhite);
            item.Background = myBrush;
            item.HorizontalAlignment = HorizontalAlignment.Stretch;

            if (txtNazwa.Text == "")
                l3.Visibility = Visibility.Visible;

            else if (txtNazwa.Text != "")
            {
                l3.Visibility = Visibility.Hidden;
                lista2.Items.Add(item);
                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            btnN1.Visibility = Visibility.Visible;
            btnN2.Visibility = Visibility.Visible;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (txtPL.Text != "" && txtENG.Text != "")
            {
                btnZatwierdz.IsEnabled = true;
                l1.Visibility = Visibility.Hidden;
                l2.Visibility = Visibility.Hidden;
            }

            else if (txtPL.Text != "" && txtENG.Text == "")
                l1.Visibility = Visibility.Hidden;

            else if (txtPL.Text == "" && txtENG.Text != "")
                l2.Visibility = Visibility.Hidden;

            else if(txtPL.Text == "" && txtENG.Text == "")
            {
                l1.Visibility = Visibility.Visible;
                l2.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "")
                l1.Visibility = Visibility.Visible;
            else if (txtENG.Text == "")
                l2.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            btnN1.Visibility = Visibility.Visible;
            btnN2.Visibility = Visibility.Visible;
        }
    }
}
