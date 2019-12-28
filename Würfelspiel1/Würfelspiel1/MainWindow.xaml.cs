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

namespace Würfelspiel1
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
            int counter = 0;
            int DieCast;
            Random rnd = new Random();
            
            txtResult.Text = "";

            do
            {
                DieCast = rnd.Next(1, 7);

                txtResult.Text += DieCast.ToString() + " ";
                counter += 1;
            }
            while (DieCast != 6);

            lblCount.Content = "Sie haben " + counter.ToString() + "-mal gewürfelt.";

        }
    }
}
