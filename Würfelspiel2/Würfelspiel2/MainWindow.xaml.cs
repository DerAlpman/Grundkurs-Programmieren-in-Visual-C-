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

namespace Würfelspiel2
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
            short n;
            int sixes = 0;
            int dieCast;
            Random rnd = new Random();

            short.TryParse(txtInput.Text, out n);
            lblResult.Content = "";

            try
            {
                if (n <= 0)
                    throw new Exception();

                for (int i = 1; i <= n; i++)
                {
                    if ((dieCast = rnd.Next(1, 7)) == 6)
                        sixes += 1;
                    //txtResult.Text += " " + dieCast.ToString();
                }

                lblResult.Content = "Sie haben " + sixes.ToString() + "-mal die \"6\" gewürfelt.";
            }
            catch (Exception)
            {
                MessageBox.Show("Zahl nicht zulässig!", "Hinweis");
            }
        }
    }
}
