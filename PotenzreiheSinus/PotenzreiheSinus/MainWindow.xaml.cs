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

namespace PotenzreiheSinus
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

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int i;
            double x, glied, phi;
            MessageBoxResult result;

            lstResult.Items.Clear();

            try
            {
                x = Convert.ToDouble(txtInput.Text.Replace(".",","));
                x = x / 180 * Math.PI;
                
                if (Math.Abs(x) >= 2 * Math.PI)
                {
                    result = MessageBox.Show("Der Wert |x| sollte < 360 sein." +
                        Environment.NewLine +  "Wollen Sie abbrechen?",
                        "Hinweis", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                        throw new Exception();
                    else if (Math.Abs(x) >= 6 * Math.PI)
                        throw new OverflowException("Argument |x| zu groß.");
                }

                txtOutput.Text = Math.Sin(x).ToString("F12");
                lstResult.Items.Add(" i        phi          glied");
                lstResult.Items.Add("---------------------------------");

                i = 1; glied = x; phi = x;
                do
                {
                    glied = -glied * x * x / (2 * i * (2 * i + 1));
                    phi += glied;
                    i += 1;
                    lstResult.Items.Add(i.ToString("00") + "  " +
                        phi.ToString("f12") + "   " +
                        glied.ToString("e4"));
                }
                while (Math.Abs(glied) >= 1e-15);
            }
            catch (FormatException)
            {
                txtOutput.Text = "";
                lstResult.Items.Clear();
                MessageBox.Show("Falsches Eingabeformat.","Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                txtOutput.Text = "";
            }
            finally
            {
                txtInput.Focus();
            }

        }
    }
}
