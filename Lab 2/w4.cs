using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace LABbb_2
{
    class window4
    {
        private static bruh m = new bruh();
        private static Window mw;
        private static Window w4 = new Window();
        public static Grid g = new Grid();

        private void goBack(object sender, RoutedEventArgs e)
        {
            w4.Hide();
            mw.Show();
        }
        public void Show()
        {
            w4.Show();
        }
        public window4(Window main)
        {
            // window
            mw = main;
            w4.Name = "w3";
            w4.Title = "Інформація";
            w4.ResizeMode = ResizeMode.NoResize;
            w4.Height = 258;
            w4.Width = 450;
            w4.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // label
            Label L1 = new Label();
            L1.HorizontalAlignment = HorizontalAlignment.Center;
            L1.VerticalAlignment = VerticalAlignment.Center;
            L1.FontSize = 25;
            L1.Content = "Роботу виконав студент\nгрупи КП-11\nБодаква Кирил Ігорович";
            m.SetMargin(L1, 69, 61, 0, 79);

            // button
            Button B1 = new Button();
            B1.HorizontalAlignment = HorizontalAlignment.Left;
            B1.VerticalAlignment = VerticalAlignment.Top;
            B1.HorizontalContentAlignment = HorizontalAlignment.Center; //
            B1.VerticalContentAlignment = VerticalAlignment.Center; //
            m.SetMargin(B1, 294, 0, 155, 0);
            B1.Content = "До меню";
            B1.Height = 46;
            B1.Width = 124;
            B1.Click += goBack;

            g.Children.Add(L1);
            g.Children.Add(B1);
            w4.Content = g;
            w4.Show();
        }
    }
}