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

namespace CheckISBN
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

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            int a, b, c, d, e1;
            string strISBN;
            long lISBN;
            try
            {
                // Check, if input are numbers, else PARSE throws FormatException.
                a = int.Parse(txtA.Text);
                b = int.Parse(txtB.Text);
                c = int.Parse(txtC.Text);
                d = int.Parse(txtD.Text);
                e1 = int.Parse(txtE.Text);

                // Concatenate and clean input.
                strISBN = txtA.Text + txtB.Text + txtC.Text + txtD.Text + txtE.Text;

                // Check input.
                // First number must be 978 or 979
                if (a != 978 && a != 979)
                    throw new Exception("Erste Ziffer der ISBN muss 978 oder 979 sein.");
                // ISBN must have 13 digits.
                if (strISBN.Length != 13)
                    throw new Exception("ISBN muss aus 13 Ziffern bestehen.");
                
                // Convert to make the check.
                lISBN = Convert.ToInt64(strISBN);

                for (int i = 1; i <= 13; i++)
                {
                    if (i % 2 == 0)
                        sum += 3 * Convert.ToInt16(lISBN % 10);
                    else
                        sum += Convert.ToInt16(lISBN % 10);
                    lISBN /= 10;
                }

                if (sum % 10 == 0)
                    lblResult.Content = "ISBN ist in Ordung.";
                else
                    lblResult.Content = "ISBN ist nicht in Ordnung.";

            }
            catch (FormatException)
            {
                MessageBox.Show("ISBN darf nur Zahlen enthalten.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
