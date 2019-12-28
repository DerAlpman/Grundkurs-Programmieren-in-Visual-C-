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

namespace BinaryToDecimal
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

        private int BinToDec(string bin)
        {
            int i, n, dec, potenz2;
            char[] chbin;

            n = bin.Length;
            chbin = bin.ToCharArray();

            for(i = 0; i < n; i++)
                if (chbin[i] != '0' && chbin[i] != '1')
                    throw new Exception("Die eingegebene Zahl ist keine Binärzahl!");

            Array.Reverse(chbin);
            dec = int.Parse(chbin[0].ToString());
            potenz2 = 1;

            for (i = 1; i < n; i++)
            {
                potenz2 = checked(potenz2 * 2);
                dec += int.Parse(chbin[i].ToString()) * potenz2;
            }

            return dec;
        }

        private double BinToDec2(string bin)
        {
            int i, n, dec, potenz2;
            char[] chbin;

            n = bin.Length - 1;
            chbin = bin.ToCharArray();

            for (i = 0; i < n; i++)
                if (chbin[i] != '0' && chbin[i] != '1')
                    throw new Exception("Die eingegebene Zahl ist keine Binärzahl!");

            potenz2 = Convert.ToInt32(Math.Pow(2, n));
            dec = int.Parse(chbin[0].ToString()) * potenz2;

            for (i = 1; i < n; i++)
            {
                potenz2 = checked(potenz2 / 2);                                
                dec += int.Parse(chbin[i].ToString()) * potenz2;
            }

            dec += int.Parse(chbin[n].ToString());

            return dec;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            txtDecimal.Text = "";
            string strBin = txtBinary.Text;
            char[] splitChars = {' ','.', ':'};
            string[] temp;
            temp = strBin.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
            strBin = string.Concat(temp);

            try
            {
                txtDecimal.Text = BinToDec(strBin).ToString();
                txtDecimal2.Text = BinToDec2(strBin).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
