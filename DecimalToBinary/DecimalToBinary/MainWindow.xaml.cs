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

namespace DecimalToBinary
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

        private string DecToBin(int dec)
        {
            string bin = "";

            while (dec != 0)
            {
                bin = (dec % 2).ToString() + bin;
                dec /= 2;
            }

            return bin;
        }

        private string DecToBinR(int dec)
        {
            string bin;

            if (dec > 0)
            {
                bin = (dec % 2).ToString();
                return DecToBinR(dec / 2) + bin;
            }
            else
                return "";
        }

        private void DecToBinR(int dec, ref string bin)
        {
            if (dec > 0)
            {
                bin = (dec % 2).ToString() + bin;
                DecToBinR(dec / 2, ref bin);
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int dec;
            string bin = "";

            try
            {
                dec = Convert.ToInt32(txtInput.Text);

                if (dec < 1)
                    throw new Exception("Eingabe muss größer 0 sein.");

                if (radIterative.IsChecked == true)
                    bin = DecToBin(dec);
                else if (radRecursive1.IsChecked == true)
                    bin = DecToBinR(dec);
                else
                    DecToBinR(dec, ref bin);

                txtOutput.Text = bin;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehlerhinweis");
            }
        }
    }
}
