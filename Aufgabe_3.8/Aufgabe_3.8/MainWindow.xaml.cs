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

namespace Aufgabe_3._8
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

        private void InputAChanged(object sender, TextChangedEventArgs e)
        {
            this.GetMax();
        }

        private void InputBChanged(object sender, TextChangedEventArgs e)
        {
            this.GetMax();
        }

        private void InputCChanged(object sender, TextChangedEventArgs e)
        {
            this.GetMax();
        }

        private void GetMax()
        {
            int a, b, c;

            int.TryParse(txtA.Text, out a);
            int.TryParse(txtB.Text, out b);
            int.TryParse(txtC.Text, out c);

            txtMax.Text = Math.Max(Math.Max(a, b), c).ToString();
        }
        
    }
}
