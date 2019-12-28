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

namespace TageMonat
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

        private void MonthSelected(object sender, SelectionChangedEventArgs e)
        {
            int month = cboMonth.SelectedIndex;

            switch (month + 1)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    txtDays.Text = "30";
                    break;
                case 2:
                    txtDays.Text = "28";
                    break;
                default:
                    txtDays.Text = "31";
                    break;
            }
        }
    }
}
