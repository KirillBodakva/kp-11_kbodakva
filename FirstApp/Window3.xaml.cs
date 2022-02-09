using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;

namespace FirstApp
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        char m;
        float num1, num2;
        public Window3()
        {
            InitializeComponent();
        }

        private void oneButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "1";
        }

        private void escButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Hide(); mainWindow.Show();
        }

        private void twoButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "2";
        }

        private void threeButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "3";
        }

        private void fourButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "4";
        }

        private void fiveButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "5";
        }

        private void sixButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "6";
        }

        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "7";
        }

        private void eightButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "8";
        }

        private void nineButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "9";
        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += "0";
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            m = '+';
            num1 = float.Parse(nBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            nBox.Text = "";
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            m = '-';
            num1 = float.Parse(nBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            nBox.Text = "";
        }

        private void powButton_Click(object sender, RoutedEventArgs e)
        {
            m = '*';
            num1 = float.Parse(nBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            nBox.Text = "";
        }

        private void divButton_Click(object sender, RoutedEventArgs e)
        {
            m = '/';
            num1 = float.Parse(nBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            nBox.Text = "";
        }

        private void resButton_Click(object sender, RoutedEventArgs e)
        {
            num2 = float.Parse(nBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (m == '+')
            {
                nBox.Text = (num1 + num2).ToString();
                num1 = num1 + num2;
                            }
            else if (m == '-')
            {
                nBox.Text = (num1 - num2).ToString();
                num1 = num1 - num2;
            }
            else if(m == '*')
            {
                nBox.Text = (num1 * num2).ToString();
                num1 = num1 * num2;
            }
            else if(num2 == '/')
            {
                nBox.Text = (num1 / num2).ToString();
                num1 = num1 / num2;

            }
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text = "";
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            int l = nBox.Text.Length - 1;
            string t = nBox.Text;
            nBox.Clear();
            for(int i = 0; i < l; i++)
            {
                nBox.Text = nBox.Text + t[i];
            }
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            nBox.Text += ".";
        }
    }
}
