using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.IO;

namespace LABbb_2
{
    class window1
    {
        private static Window w1 = new Window();
        private static Grid g = new Grid();
        private static bruh mm = new bruh();
        private static Window mw;

        private static Button B1;
        private static Button B2;
        private static Button B3;
        private static Button B4;
        private static Label L1;
        private static Label L2;
        private static Label L3;
        private static Label L4;
        private static TextBox T1;
        private static TextBox T2;
        private static TextBox T3;

        public window1( Window main)
        {
            mw = main;
            w1.Name = "w1";
            w1.Title = "Студенти";
            w1.Height = 520;
            w1.Width = 570;
            w1.ResizeMode = ResizeMode.NoResize;
            w1.HorizontalAlignment = HorizontalAlignment.Left;
            w1.VerticalAlignment = VerticalAlignment.Top;
            w1.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            L1 = CL(32, 127, 16, "Ввести дані", 10, 0, 0, 0);
            L2 = CL(26, 314, 12, "Нормер залікової книжки, ПІП, пошта, номер студента:", 10, 0, 32, 0);
            L3 = CL(32, 127, 16, "Видалити дані", 10, 10, 340, 0);
            L4 = CL(26, 156, 12, "Нормер залікової книжки:", 10, 0, 382, 0);
            T1 = CTB(58, 536, 16, "", 10, 0, 59, 0);
            T2 = CTB(30, 110, 16, "", 174, 0, 382, 0);
            T3 = CTB(199, 418, 16, "", 10, 0, 130, 0);
            B1 = CB(36, 110, 12, "Ввести", 436, 0, 130, 0);
            B2 = CB(36, 110, 12, "Видалити", 436, 0, 382, 0);
            B3 = CB(36, 110, 12, "До меню", 436, 0, 432, 0);
            B4 = CB(36, 110, 12, "Очистити", 436, 0, 180, 0);

            B1.Click += Read;
            B2.Click += Delete;
            B3.Click += GoBack;
            B4.Click += Clear;

            g.Children.Add(B1);
            g.Children.Add(B2);
            g.Children.Add(B3);
            g.Children.Add(B4);
            g.Children.Add(L1);
            g.Children.Add(L2);
            g.Children.Add(L3);
            g.Children.Add(L4);
            g.Children.Add(T1);
            g.Children.Add(T2);
            g.Children.Add(T3);

            w1.Content = g;
            w1.Show();
        }

        private TextBox CTB(int height = 30, int width = 110, int fontsize = 16,
            string tx = "", int left = 0, int right = 0, int top = 0, int bottom = 0)
        {
            TextBox t = new TextBox();
            t.Height = height;
            t.Width = width;
            t.FontSize = fontsize;
            t.Text = tx;
            mm.SetMargin(t, left, right, top, bottom);
            t.HorizontalAlignment = HorizontalAlignment.Left;
            t.VerticalAlignment = VerticalAlignment.Top;
            return t;
        }

        private Label CL(int height = 36, int width = 126, int fontsize = 12,
            string content = "text", int left = 0, int right = 0, int top = 0, int bottom = 0)
        {
            Label l = new Label();
            l.Height = height;
            l.Width = width;
            l.FontSize = fontsize;
            l.Content = content;
            mm.SetMargin(l, left, right, top, bottom);
            l.HorizontalAlignment = HorizontalAlignment.Left;
            l.VerticalAlignment = VerticalAlignment.Top;
            return l;
        }

        private Button CB(int height = 36, int width = 110, int fontsize = 12,
            string content = "text", int left = 0, int right = 0, int top = 0, int bottom = 0)
        {
            Button b = new Button();
            b.Height = height;
            b.Width = width;
            b.FontSize = fontsize;
            b.Content = content;
            mm.SetMargin(b, left, right, top, bottom);
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.VerticalAlignment = VerticalAlignment.Top;
            return b;
        }

        public void GoBack(object sender, RoutedEventArgs e)
        {
            w1.Hide();
            mw.Show();
        }

        private void ShowData()
        {
            StreamReader read = new StreamReader("lab2.txt");
            string text = read.ReadToEnd();
            read.Close();
            T3.Text = text;
        }

        private void Read(object sender, RoutedEventArgs e)
        {
            StreamWriter m = new StreamWriter("lab2.txt", true);
            string text = T1.Text;
            m.WriteLine(text);
            m.Close();
            T1.Text = "";
            ShowData();
        }
        
        private void Clear(object sender, RoutedEventArgs e)
        {
            StreamWriter clear = new StreamWriter("lab2.txt", false);
            clear.Write("");
            clear.Close();
            ShowData();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            string n = T2.Text;
            string lastText = "";
            StreamReader read = new StreamReader("lab2.txt");
            while (!read.EndOfStream)
            {
                string line = read.ReadLine();
                string[] arr = line.Split(", ");
                string need = arr[0];
                if (need != n)
                {
                    lastText += $"{line}\n";
                }
            }
            read.Close();
            StreamWriter write = new StreamWriter("lab2.txt");
            write.Write(lastText);
            write.Close();
            ShowData();
            T2.Text = "";
        }

        public void Show()
        {
            w1.Show();
        }
    }
}