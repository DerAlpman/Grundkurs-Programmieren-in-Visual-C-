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

namespace Matrizenaddition
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

        private int[,] a, b, c;

        private void TestMatDimensions(int[,] a, int[,] b, out int m, out int n)
        {
            int mA, mB, nA, nB;
            mA = a.GetLength(0);
            mB = b.GetLength(0);
            nA = a.GetLength(1);
            nB = b.GetLength(1);

            if (mA == mB && nA == nB)
            { 
                m = mA;
                n = nA;
            }
            else
            {
                m = 0; 
                n = 0; 
            }
        }

        private void AddMat(int[,] a, int[,] b, out int[,] c, out bool isErr)
        {
            int m, n;
            isErr = false;

            TestMatDimensions(a, b, out m, out n);
            if (m == 0)
            {
                isErr = true;
                c = null;
            }
            else
            {
                c = new int[m, n];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        c[i, j] = a[i, j] + b[i, j];
            }
        }

        private void WriteMatrix(int[,] a, ListBox lstBox)
        {
            int m, n;
            string zeile;

            m = a.GetLength(0);
            n = a.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                zeile = "";
                for (int j = 0; j < n; j++)
                    zeile += "  " + a[i, j].ToString();
                lstBox.Items.Add(zeile);
            }
        }

        private void Clear()
        {
            lstA.Items.Clear();
            lstB.Items.Clear();
            lstC.Items.Clear();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isError;
            lstC.Items.Clear();

            if (a != null && b != null)
            {
                AddMat(a, b, out c, out isError);
                if (isError == true)
                    lstC.Items.Add("Dimensionsfehler");
                else
                    WriteMatrix(c, lstC);
            }
            else
            {
                lstC.Items.Add("Erst Werte für A und B eingeben.");
            }


        }

        private void btnTextvalues_Click(object sender, RoutedEventArgs e)
        {
            a = new int[,] { { 2, 3 }, { -2, -1 }, { 1, -1 }, { 3, 0 } };
            b = new int[,] { { 2, 4 }, { -2, 2 }, { 1, -2 }};
            Clear();

            WriteMatrix(a, lstA);
            WriteMatrix(b, lstB);
        }
    }
}
