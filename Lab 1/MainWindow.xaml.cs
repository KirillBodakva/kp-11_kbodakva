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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            //this.Close();
        }

        private void v1_Click(object sender, RoutedEventArgs e)
        {
            Window1 aa = new Window1();
            Hide(); aa.Show();
        }

        private void v2_Click(object sender, RoutedEventArgs e)
        {
            Window2 ab = new Window2();
            Hide(); ab.Show();
        }

        private void v3_Click(object sender, RoutedEventArgs e)
        {
            Window3 ac = new Window3();
            Hide(); ac.Show();
        }

        private void v4_Click(object sender, RoutedEventArgs e)
        {
            Window4 ad = new Window4();
            Hide(); ad.Show();
        }
    }
}
