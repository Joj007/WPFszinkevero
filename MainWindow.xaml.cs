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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void SzinKeveres(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
            zoldErtek.Content = Convert.ToString(Math.Round(sliZold.Value));
            kekErtek.Content = Convert.ToString(Math.Round(sliKek.Value));
            pirosErtek.Content = Convert.ToString(Math.Round(sliPiros.Value));
        }

        public MainWindow()
        {

        }

        private void Rogzit(object sender, RoutedEventArgs e)
        {
            string szinAdatok = Convert.ToString(Math.Round(sliPiros.Value)) + ";" + Convert.ToString(Math.Round(sliZold.Value)) + ";" + Convert.ToString(Math.Round(sliKek.Value));
            if (!ListaTeszt(szinAdatok) || lbSzinek.Items.Count == 0)
            {
                lbSzinek.Items.Add(szinAdatok);
            }
            else
            {
                MessageBox.Show("Ilyen szín már létezik!");
            }
            
        }

        private void Torol(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex<0)
            {
                MessageBox.Show("Nincsen egy elem sem kijelölve!");
            }
            else
            {
                lbSzinek.Items.Remove(lbSzinek.SelectedItem);
            }
            
        }

        private void Urites(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }

        private bool ListaTeszt(string szinAdatok)
        {
            bool letezik = false;
            foreach (var szin in lbSzinek.Items)
            {
                string piros = szin.ToString().Split(";")[0];
                string zold = szin.ToString().Split(";")[1];
                string kek = szin.ToString().Split(";")[2];
                if (szinAdatok == piros + ";" + zold + ";" + kek)
                {
                    letezik = true;
                    break;
                }
            }

            return letezik;
        }


        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            {
                string piros = lbSzinek.SelectedItem.ToString().Split(";")[0];
                string zold = lbSzinek.SelectedItem.ToString().Split(";")[1];
                string kek = lbSzinek.SelectedItem.ToString().Split(";")[2];
                rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(piros), Convert.ToByte(zold), Convert.ToByte(kek)));
                sliPiros.Value = Convert.ToDouble(lbSzinek.SelectedItem.ToString().Split(";")[0]);
                sliZold.Value = Convert.ToDouble(lbSzinek.SelectedItem.ToString().Split(";")[1]);
                sliKek.Value = Convert.ToDouble(lbSzinek.SelectedItem.ToString().Split(";")[2]);
            }
            
        }
    }
}
