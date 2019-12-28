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

namespace Textanalysis
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

        private string[] words;
        private string newline = System.Environment.NewLine;

        private string[] SplitText(string text)
        {
             string[] strSep = {newline, " ", ".", ",", "?", ":", ";", "!", "\"", "(", ")"};

            return text.Split(strSep, StringSplitOptions.RemoveEmptyEntries);

        }
        
        private void btnBuildIndex(object sender, RoutedEventArgs e)
        {

        }

        private void btnSortWords(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnalyseText(object sender, RoutedEventArgs e)
        {
            string text = txtInput.
            words = SplitText(text);

            txtResult.Text = "Der Text besteht aus " + words.Length + " Wörtern und aus " + txtInput.Text.Length + " Zeichen.";

            for (int i = 0; i < words.Length; i++)
                txtWordList.Text += i + "    " + words[i] + newline;
        }
    }
}
