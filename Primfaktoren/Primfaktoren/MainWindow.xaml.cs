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

namespace Primfaktoren
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            txtPrimFactors.Text = "";

            try
            {
                int n = int.Parse(txtInput.Text);
                double nRoot = Math.Sqrt(n);
                if (n < 2)
                    throw new Exception("Zahl muss >= 2 sein.");

                int prim = 2;

                do
                {
                    if (n % prim != 0)
                        prim += 1;
                    else
                    {
                        n /= prim;

                        txtPrimFactors.Text += " " + prim.ToString();
                    }
                }
                while (n > 1 && prim <= nRoot);

                if (n > prim + 1)
                    txtPrimFactors.Text += " " + n.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte überprüfen Sie die eingebene Zahl.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hinweis");
            }

        }
    }
}
