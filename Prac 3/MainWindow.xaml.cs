using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Prac_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            Hide();
            admin.Show();
        }
        private void UserMode_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            Hide();
            user.Show();
        }
        private void Exit(object sender, RoutedEventArgs e) =>
            System.Windows.Application.Current.Shutdown();
        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
            Dev dev = new Dev();
            dev.Show();
        }
        private void Exit(object sender, System.ComponentModel.CancelEventArgs e) =>
            System.Windows.Application.Current.Shutdown();
    }
}
