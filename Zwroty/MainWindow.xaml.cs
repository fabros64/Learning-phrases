﻿using System;
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

        FileStream stream;
        StreamWriter writer;
        StreamReader reader;
        

        public MainWindow()
        {
            
            InitializeComponent();

            try
            {
                stream = new FileStream("bazy" + ".dat", FileMode.Open); 
            }
            catch
            {
                stream = new FileStream("bazy" + ".dat", FileMode.Create);          
            }

            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);


            while(!reader.EndOfStream)
            {

                ListBoxItem item = new ListBoxItem();
                item.Content = reader.ReadLine();
                SolidColorBrush myBrush = new SolidColorBrush(Colors.FloralWhite);
                item.Background = myBrush;
                item.HorizontalAlignment = HorizontalAlignment.Stretch;

                lista.Items.Add(item);

                Poszczegolna_Baza baza = new Poszczegolna_Baza(item.Content.ToString());

                

                FileStream stream2 = new FileStream(item.Content.ToString() + ".dat", FileMode.Open);
                StreamReader reader2 = new StreamReader(stream2);

                int i = 1;
                Zwrot zwrot = new Zwrot();

                while (!reader2.EndOfStream)
                {
                    if (i % 2 != 0)
                    {
                        zwrot = new Zwrot();
                        zwrot.setPL(reader2.ReadLine());
                    }

                    else if (i % 2 == 0)
                    {
                        zwrot.setENG(reader2.ReadLine());
                        baza.Dodaj_Zwrot(zwrot);
                    }

                    stream2.Position++;
                    i++;
                }

                App.bazy.Dodaj_Baze(baza);

                stream.Position++;

                
            }

            

            stream.Position = stream.Length;

            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnOtworz.IsEnabled = true;
            btnUsun.IsEnabled = true;
            btnTEST.IsEnabled = true;
            Edit.IsEnabled = true;

            Edit.Margin = new Thickness(727, Mouse.GetPosition(lista).Y + Edit.Height + 20, 0, 0);
            Edit.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NowaBaza nb = new NowaBaza(btnNowa, btnTEST, lista, btnOtworz, btnUsun, writer, btnOtworz, btnUsun, stream);
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
            Baza baza = new Baza(this, lista, btnNowa, btnTEST, writer);
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
            File.Delete(App.bazy.getBazy().ElementAt(lista.SelectedIndex).getNazwa() + ".dat");

            App.bazy.getBazy().RemoveAt(lista.SelectedIndex);
            lista.Items.RemoveAt(lista.SelectedIndex);
            btnUsun.IsEnabled = false;
            btnOtworz.IsEnabled = false;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            writer.Close();
            reader.Close();

            stream = new FileStream("bazy" + ".dat", FileMode.Truncate);
            writer = new StreamWriter(stream);

            foreach (var item in App.bazy.getBazy())
                writer.WriteLine(item.getNazwa());

            writer.Close();
            stream.Close();

            this.Close();

        }

        private void btnTEST_Click(object sender, RoutedEventArgs e)
        {
            
            TEST test = new TEST(App.bazy.getBazy().ElementAt(lista.SelectedIndex), this);

            this.Visibility = Visibility.Collapsed;
            test.Show();
        }

        public void exit()
        {
            if (App.exit == true)
                this.Close();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (App.exit == true)
                this.Close();
        }

        private void lista_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //btnOtworz.IsEnabled = true;
            //btnUsun.IsEnabled = true;
        }

        private void lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Baza baza = new Baza(this, lista, btnNowa, btnTEST, writer);
            this.Visibility = Visibility.Collapsed;
            baza.Top = this.Top;
            baza.Left = this.Left;
            baza.Show();

        }

        private void lista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                File.Delete(App.bazy.getBazy().ElementAt(lista.SelectedIndex).getNazwa() + ".dat");

                App.bazy.getBazy().RemoveAt(lista.SelectedIndex);
                lista.Items.RemoveAt(lista.SelectedIndex);
                btnUsun.IsEnabled = false;
                btnOtworz.IsEnabled = false;
            }

            else if(e.Key == Key.Enter)
            {
                Baza baza = new Baza(this, lista, btnNowa, btnTEST, writer);
                this.Visibility = Visibility.Collapsed;
                baza.Top = this.Top;
                baza.Left = this.Left;
                baza.Show();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nazwa nazwa = new Nazwa(App.bazy.getBazy().ElementAt(lista.SelectedIndex).getNazwa(), lista, stream, Edit, btnTEST);
            nazwa.Top = this.Top + Edit.Margin.Top;
            nazwa.Left = this.Left + lista.Width/2 + 30;
            nazwa.Show();
        }

        private void BtnTranslator_Click(object sender, RoutedEventArgs e)
        {
            Translator translator = new Translator(BtnTranslator, this);
            translator.Left = this.Left + this.Width - translator.Width - (this.Width - translator.Width) / 2;
            translator.Top = this.Top + this.Height - translator.Height - (this.Height - translator.Height) / 2;
            translator.Show();
        }
    }
}
