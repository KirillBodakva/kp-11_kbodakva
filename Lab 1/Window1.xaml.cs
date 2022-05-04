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
using System.IO;

namespace FirstApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void show() //показ записів
        {
            StreamReader read = new StreamReader("lab1.txt");
            string text = read.ReadToEnd();
            read.Close();
            TB3.Text = text;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e) //clear
        {
            StreamWriter clear = new StreamWriter("lab1.txt",false);
            clear.Write("");
            clear.Close();
            show();
        }

        private void Esc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Hide(); mainWindow.Show();
        }

        private void Enter_Click(object sender, RoutedEventArgs e) //enter info
        {
            StreamWriter m = new StreamWriter("lab1.txt", true);
            string text = TB1.Text;
            m.WriteLine(text);
            m.Close();
            TB1.Text = "";
            show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //delete
        {
            string n = TB2.Text;
            string lastText = "";
            StreamReader read = new StreamReader("lab1.txt");
            while (!read.EndOfStream)
            {
                string line = read.ReadLine();
                string[] arr = line.Split(", ");
                string need = arr[0];
                if(need != n)
                {
                    lastText += $"{line}\n";
                }
            }
            read.Close();
            StreamWriter write = new StreamWriter("lab1.txt");
            write.Write(lastText);
            write.Close();
            show();
            TB2.Text = "";
        }
    }
}
