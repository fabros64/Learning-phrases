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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NowaBaza nb = new NowaBaza(btnNowa, btnTEST, lista, btnOtworz, btnUsun, writer);
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
    }
}
