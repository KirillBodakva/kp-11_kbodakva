using System.Windows;

namespace LABbb_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private window1 w1 = null;
        private window2 w2 = null;
        private window3 w3 = null;
        private window4 w4 = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (w4 is null)
            {
                w4 = new window4(this);
            }
            else
            {
                w4.Show();
            }
            Hide();
        }

        private void ButtonE_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (w3 is null)
            {
                w3 = new window3(this);
            }
            else
            {
                w3.Show();
            }
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (w2 is null)
            {
                w2 = new window2(this);
            }
            else
            {
                w2.Show();
            }
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (w1 is null)
            {
                w1 = new window1(this);
            }
            else
            {
                w1.Show();
            }
            Hide();
        }
    }
}
