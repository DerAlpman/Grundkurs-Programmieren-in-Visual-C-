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

namespace Class_Rectangle
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double l, w;
            Rectangle myRect;

            try
            {
                l = Convert.ToDouble(txtLength.Text.Replace(".", ","));
                w = Convert.ToDouble(txtWidth.Text.Replace(".", ","));

                myRect = new Rectangle(l, w);
                txtArea.Text = myRect.FormatF2(myRect.Area);
                txtPerimeter.Text = myRect.FormatF2(myRect.Perimeter); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehlerhinweis");
            }
        }
    }
}
