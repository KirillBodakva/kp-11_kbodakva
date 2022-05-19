using System.Windows;
using System.Windows.Controls;

namespace LABbb_2
{
    class window2
    {
        private void goBack(object sender, RoutedEventArgs e)
        {
            w2.Hide();
            mw.Show();
        }

        public void Show()
        {
            w2.Show();
        }

        private ComboBox CBCreate()
        {
            ComboBox CB = new ComboBox();
            ComboBoxItem CBI1 = new ComboBoxItem();
            ComboBoxItem CBI2 = new ComboBoxItem();
            CB.FontSize = 12;
            CBI1.FontSize = 12; CBI1.Content = "X"; CB.Items.Add(CBI1);
            CBI2.FontSize = 12; CBI2.Content = "O"; CB.Items.Add(CBI2);
            CB.HorizontalContentAlignment = HorizontalAlignment.Center;
            CB.VerticalContentAlignment = VerticalAlignment.Center;
            return CB;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].SelectedValue = null;
            }
        }

        private static Window w2 = new Window();
        private static Window mw;
        private static Grid g = new Grid();
        private static ComboBox[] a = new ComboBox[25];
        private static Button[] b = new Button[2];
        private static int rows = 5, cols = 6;
        private static RowDefinition[] arr1 = new RowDefinition[rows];
        private static ColumnDefinition[] arr2 = new ColumnDefinition[cols];

        public window2(Window main)
        {
            mw = main;
            w2.Name = "w2";
            w2.Title = "Гра";
            w2.Height = 258;
            w2.Width = 450;
            w2.ResizeMode = ResizeMode.NoResize;
            w2.HorizontalAlignment = HorizontalAlignment.Center;
            w2.VerticalAlignment = VerticalAlignment.Center;
            w2.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            for (int i = 0; i < 2; i++)
            {
                b[i] = new Button();
                b[i].FontSize = 12;
                g.Children.Add(b[i]);
            }
            b[0].Content = "До меню";
            b[1].Content = "Спочатку";
            b[0].Click += goBack;
            b[1].Click += Reset;

            for (int i = 0; i < 25; i++)
            {
                a[i] = CBCreate();
                g.Children.Add(a[i]);
            }

            for (int i = 0; i < rows; i++)
            {
                arr1[i] = new RowDefinition();
                g.RowDefinitions.Add(arr1[i]);
            }
            for (int i = 0; i < cols; i++)
            {
                arr2[i] = new ColumnDefinition();
                g.ColumnDefinitions.Add(arr2[i]);
            }

            int c = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    Grid.SetRow(a[c], i);
                    Grid.SetColumn(a[c], j);
                    c++;
                }
            }
            for(int i = 0; i < 2; i++)
            {
                Grid.SetRow(b[i], i);
                Grid.SetColumn(b[i], 6);
            }
            w2.Content = g;
            w2.Show();
        }
    }
}