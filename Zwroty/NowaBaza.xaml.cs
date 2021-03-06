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
using System.IO;

namespace Zwroty
{
    /// <summary>
    /// Logika interakcji dla klasy NowaBaza.xaml
    /// </summary>
    public partial class NowaBaza : Window
    {
        Button btnN1, btnN2;
        ListBox lista2;
        Poszczegolna_Baza baza = new Poszczegolna_Baza();
        Button otworz, usun;
        StreamWriter writer;
        Button b1, b2;
        FileStream bazy;
        

        public NowaBaza(Button btn1, Button btn2, ListBox lista, Button otworz, Button usun, StreamWriter writer, Button b1, Button b2, FileStream bazy)
        {
            InitializeComponent();
            btnN1 = btn1;
            btnN2 = btn2;
            this.otworz = otworz;
            this.usun = usun;
            this.writer = writer;
            this.b1 = b1;
            this.b2 = b2;
            this.bazy = bazy;
            

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
            lista2.FontSize = 28;

            
           
            

            if (txtNazwa.Text == "")
                l3.Visibility = Visibility.Visible;

            else if (txtNazwa.Text != "")
            {

                try
                {
                    FileStream CzyJestBaza = new FileStream(txtNazwa.Text + ".dat", FileMode.Open);
                    MessageBox.Show(this, "Baza o podanej nazwie już istnieje!", "Błąd");
                    
                    CzyJestBaza.Close();
                }
                catch
                {
                    lista2.Items.Add(item);
                    baza.setNazwa(txtNazwa.Text);
                    App.bazy.Dodaj_Baze(baza);
                    writer.WriteLine(txtNazwa.Text);

                    FileStream stream2 = new FileStream(txtNazwa.Text + ".dat", FileMode.OpenOrCreate);
                    writer = new StreamWriter(stream2);

                    foreach (var item2 in baza.getZwroty())
                    {
                        writer.WriteLine(item2.getPL());
                        writer.WriteLine(item2.getENG());
                    }

                    this.Close();
                    writer.Close();
                    stream2.Close();
                }

                l3.Visibility = Visibility.Hidden;
 
            }

            btnN1.IsEnabled = true;
            btnN2.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            btnN1.IsEnabled = true;
            btnN2.IsEnabled = false;

            this.Close();

            //b1.IsEnabled = true;
            //b2.IsEnabled = true;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodawanie();
        }

        private void listZwroty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUsun.IsEnabled = true;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Dodawanie();
            }
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            baza.getZwroty().RemoveAt(listZwroty.SelectedIndex);
            listZwroty.Items.RemoveAt(listZwroty.SelectedIndex);
            btnUsun.IsEnabled = false;
        }

        private void btnRev_Click(object sender, RoutedEventArgs e)
        {
            if (lPL.Content.ToString().Equals("PL"))
            {
                lPL.Content = "ENG";
                lENG.Content = "PL";
            }

            else
            {
                lPL.Content = "PL";
                lENG.Content = "ENG";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            btnN1.IsEnabled = true;
            btnN2.IsEnabled = false;

        }

        private void Dodawanie()
        {
            if (txtPL.Text != "" && txtENG.Text != "")
            {
                btnZatwierdz.IsEnabled = true;
                l1.Visibility = Visibility.Hidden;
                l2.Visibility = Visibility.Hidden;


                ListBoxItem item = new ListBoxItem();
                item.Content = txtPL.Text + " - " + txtENG.Text;
                SolidColorBrush myBrush = new SolidColorBrush(Colors.FloralWhite);
                item.Background = myBrush;
                item.HorizontalAlignment = HorizontalAlignment.Stretch;
                listZwroty.Items.Add(item);

                baza.Dodaj_Zwrot(txtPL.Text, txtENG.Text);

                txtPL.Text = "";
                txtENG.Text = "";


            }

            else if (txtPL.Text != "" && txtENG.Text == "")
            {
                l1.Visibility = Visibility.Hidden;
                l2.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "" && txtENG.Text != "")
            {
                l2.Visibility = Visibility.Hidden;
                l1.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "" && txtENG.Text == "")
            {
                l1.Visibility = Visibility.Visible;
                l2.Visibility = Visibility.Visible;
            }

            else if (txtPL.Text == "")
                l1.Visibility = Visibility.Visible;
            else if (txtENG.Text == "")
                l2.Visibility = Visibility.Visible;
        }
    }
}
