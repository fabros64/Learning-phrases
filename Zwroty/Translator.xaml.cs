using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
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
    /// Logika interakcji dla klasy Translator.xaml
    /// </summary>
    public partial class Translator : Window
    {    
        Button translator;
        Window okno;
        StreamWriter writer;

        public Translator(Button translator, Window okno)
        {
            InitializeComponent();
            Warning1.Visibility = Visibility.Collapsed;          
            
            this.translator = translator;
            this.okno = okno;            

            this.Left = okno.Left + 65;
            this.Top = okno.Top + okno.Height / 2;
        }

        public String Translate(String word, string toLanguage, string fromLanguage)
        {
            toLanguage = toLanguage.ToLower();
            fromLanguage = fromLanguage.ToLower();

            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };   
            
            var result = webClient.DownloadString(url);

            try
            {                
                result = result.Substring(4, result.IndexOf("\"",4)-4);
            
                return result;               
            }
            catch
            {
                return "Błąd";
            }
        }

        public String TranslateText(string word, string fromLanguage, string toLanguage)
        {
            toLanguage = toLanguage.ToLower();
            fromLanguage = fromLanguage.ToLower();

            string langpair = fromLanguage + "|" + toLanguage;

            try
            {
                var url = $"https://translate.google.com/?hl=pl#view=home&op=translate&sl={fromLanguage}&tl={toLanguage}&text={HttpUtility.UrlEncode(word)}";
                WebClient webClient = new WebClient();
                webClient.Encoding = System.Text.Encoding.UTF8;                                

                var result = webClient.DownloadString(url);

                MessageBox.Show(result);
                return result;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                return string.Empty;
            }
        }
      

        private void BtnTlumaczClick(object sender, RoutedEventArgs e)
        {
                  Tlumacz();
        }

        private void Tlumacz()
        {
            if (txt1.Text != "")
            {
                Warning1.Visibility = Visibility.Hidden;
                //txt2.Text = TranslateText(txt1.Text, l1.Content.ToString(), l2.Content.ToString());
                txt2.Text = Translate(txt1.Text.ToString(), l2.Content.ToString(), l1.Content.ToString());                
            }

            else
            {
                Warning1.Visibility = Visibility.Visible;
            }
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            translator.IsEnabled = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            translator.IsEnabled = true;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Tlumacz();
        }
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (l1.Content.ToString().Equals("PL"))
            {
                l1.Content = "EN";
                l2.Content = "PL";
            }

            else
            {
                l1.Content = "PL";
                l2.Content = "EN";
            }
        }
    }
}
