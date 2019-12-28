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

namespace Notenskala
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

        private void txtPoints_TextChanged(object sender, TextChangedEventArgs e)
        {
            int points;

            if (txtPoints.Text != "")
            {
                points = Convert.ToInt32(txtPoints.Text);

                switch (points)
                {
                    case 15:
                    case 14:
                    case 13:
                        txtNote.Text = "1";
                        break;
                    case 12:
                    case 11:
                    case 10:
                        txtNote.Text = "2";
                        break;
                    case 9:
                    case 8:
                    case 7:
                        txtNote.Text = "3";
                        break;
                    case 6:
                    case 5:
                    case 4:
                        txtNote.Text = "4";
                        break;
                    case 3:
                    case 2:
                    case 1:
                        txtNote.Text = "5";
                        break;
                    case 0:
                        txtNote.Text = "6";
                        break;
                    default:
                        txtNote.Text = "###";
                        break;
                }

            }
            else
                txtNote.Text = "";
        }
    }
}
