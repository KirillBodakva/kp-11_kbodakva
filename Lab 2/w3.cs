using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LABbb_2
{
    class window3
    {
        private static Window w3 = new Window();
        private static Window mw;
        private static Grid g = new Grid();
        private static TextBox TB1 = new TextBox();
        private void goBack(object sender, RoutedEventArgs e)
        {
            w3.Hide();
            mw.Show();
        }
        public void Show()
        {
            w3.Show();
        }
        public window3(Window main)
        {
            mw = main;
            w3.Name = "w3";
            w3.Title = "Калькулятор";
            w3.ResizeMode = ResizeMode.NoResize;
            w3.Height = 300;
            w3.Width = 200;
            w3.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TB1.VerticalContentAlignment = VerticalAlignment.Center;
            TB1.HorizontalContentAlignment = HorizontalAlignment.Center;
            TB1.FontSize = 20;

            Button[,] buttons = new Button[5, 4];
            for(int i = 0; i< 5; i++)
            {
                for(int j = 0; j< 4; j++)
                {
                    Button B1 = new Button();
                    buttons[i, j] = B1;
                    B1.FontSize = 20;
                    B1.Content = "button";
                    B1.VerticalContentAlignment= VerticalAlignment.Center;
                    B1.HorizontalContentAlignment =HorizontalAlignment.Center;
                    g.Children.Add(buttons[i, j]);
                    B1.Click += tButton_Click;
                }
            }

            BuTTons(buttons);
            int rows = 6, cols = 4;
            RowDefinition[] arr = new RowDefinition[rows];
            ColumnDefinition[] arr2 = new ColumnDefinition[cols];
            for(int i =0; i< rows; i++)
            {
                arr[i] = new RowDefinition();
                g.RowDefinitions.Add(arr[i]);
            }
            for (int i = 0; i < cols; i++)
            {
                arr2[i] = new ColumnDefinition();
                g.ColumnDefinitions.Add(arr2[i]);
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Grid.SetRow(buttons[i-1,j],i);
                    Grid.SetColumn(buttons[i-1,j],j);
                }
            }
            Grid.SetRow(TB1, 0);
            Grid.SetColumn(TB1, 4);
            g.Children.Add(TB1);
            w3.Content = g;
            w3.Show();
        }
        private void BuTTons(Button[,] buttons)
        {
            buttons[0, 0].Content = "Exit";
            buttons[0, 1].Content = "=";
            buttons[0, 2].Content = "C";
            buttons[0, 3].Content = "<-";
            buttons[1, 0].Content = "7";
            buttons[1, 1].Content = "8";
            buttons[1, 2].Content = "9";
            buttons[1, 3].Content = "/";
            buttons[2, 0].Content = "4";
            buttons[2, 1].Content = "5";
            buttons[2, 2].Content = "6";
            buttons[2, 3].Content = "*";
            buttons[3, 0].Content = "1";
            buttons[3, 1].Content = "2";
            buttons[3, 2].Content = "3";
            buttons[3, 3].Content = "-";
            buttons[4, 0].Content = "+/-";
            buttons[4, 1].Content = "0";
            buttons[4, 2].Content = ",";
            buttons[4, 3].Content = "+";
        }
        private void tButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = (string)((Button)e.OriginalSource).Content;
                if( a == "Exit")
                {
                    w3.Hide();
                    mw.Show();
                }
                else if (a == "C")
                {
                    TB1.Text = "";
                }
                else if (a == "+/-")
                {
                    TB1.Text += "*(-1)";
                }
                else if (a == "<-")
                {
                    if (TB1.Text != "")
                    {
                        TB1.Text = TB1.Text.Remove(TB1.Text.Length - 1, 1);
                    }
                }
                else if(a == "=")
                {
                    DataTable dt = new DataTable();
                    string res = dt.Compute(TB1.Text, null).ToString();
                    TB1.Text = res;
                }
                else
                {
                    TB1.Text += a;
                }                
            }
            catch (Exception)
            {
                TB1.Text = "Помилка";
            }
        }
    }
}