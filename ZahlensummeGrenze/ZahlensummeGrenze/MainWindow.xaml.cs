using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZahlensummeGrenze
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LimitEntered(object sender, TextChangedEventArgs e)
        {
            int i = 0, sum = 0;

            try
            {
                int limit = int.Parse(txtLimit.Text);

                do
                {
                    i += 1;
                    sum += i;
                }
                while (sum <= limit - (i + 1));

                txtLastNr.Text = i.ToString();
                txtSum.Text = sum.ToString();
            }
            catch (FormatException)
            { 
                txtLastNr.Text = "";
                txtSum.Text = "";
            }
            catch (OverflowException)
            {
                txtLastNr.Text = "";
                txtSum.Text = "";
                MessageBox.Show("Grenze für Zahlensumme zu groß.", "Fehlerhinweis");
            }
            catch (Exception ex)
            {
                txtLastNr.Text = "";
                txtSum.Text = "";
                MessageBox.Show(ex.ToString(), "Fehlerhinweis");
            }
        }
    }
}
