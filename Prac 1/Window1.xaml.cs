using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
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

namespace Prj_Soft_Protection
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool start = false; 
        int l = 0; int t = 3;
        List<TimeSpan> s = new List<TimeSpan>();
        public const string word = "длагнитор";

        public Window1()
        {
            InitializeComponent();
            VerifField.Text = word;
        }

        bool validate = false;
        Stopwatch sw;

        public void Reset()
        {
            validate = false;
            InputField.Text = "";
            s = new List<TimeSpan>();
            start = false;
            l = InputField.Text.Length;
        }

        public double Sum(int time, Func<int, double> f)
        {
            double res = 0;
            for (int i = 0; i < time; i++)
            {
                res += f(i);
            }
            return res;
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        public void Calculate(List<TimeSpan> s)
        {
            double[] coef = { 6.314, 2.92, 2.353, 2.132,
                              2.015, 1.943, 1.895, 1.86, 1.833,
                              1.813, 1.8, 1.782, 1.761, 1.75, 1.75,
                              1.74, 1.734, 1.725, 1.72};
            bool valid = true;
            for (int i = 0; i < s.Count; i++)
            {
                var y = s.ToList(); // множина тимчасових інтервалів
                y.RemoveAt(i); // множина y'
                double M = Sum(y.Count, (j) => y[j].TotalSeconds) / y.Count; //математичне сподівання
                double D = Sum(y.Count, (j) => Math.Pow(y[j].TotalSeconds - M, 2) / (y.Count - 1)); //дисперсія
                double Si = (s[i].TotalSeconds - M) / Math.Sqrt(D); //середньоквадратичне відхилення
                if (Si > coef[y.Count - 1])
                {
                    valid = false; break;
                }
            }
            if (valid)
            {
                double M = Sum(s.Count, (j) => s[j].TotalSeconds) / s.Count;
                double S = Sum(s.Count, (j) => Math.Pow(s[j].TotalSeconds - M, 2) / (s.Count - 1));
                System.IO.File.AppendAllText(@"D:\Visual Studio\\2 СЕМЕСТР\Prac 1\Prj_Soft_Protection\save.txt", $"{M} {S}\n");
            }
            t--;
            if(t == 0)
            {
                InputField.IsEnabled = false;
                MessageBox.Show("А все");
            }
            else
            {
                MessageBox.Show($"{t} осталось");
            }
        }

        private void InputField_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!validate)
            {
                validate = true;
                return;
            }
            if (l > InputField.Text.Length || InputField.Text != word.Substring(0, InputField.Text.Length))
            {
                MessageBox.Show("Ошибка");
                Reset();
                return;
            }
            l = InputField.Text.Length;
            if(l > 0)
            {
                if (!start)
                {
                    sw = new Stopwatch();
                    sw.Start();
                    start = true;
                }
                else
                {
                    sw.Stop();
                    s.Add(sw.Elapsed);
                    sw = new Stopwatch();
                    sw.Start();
                }
                if(InputField.Text == word)
                {
                    Calculate(s);
                    Reset();
                }
            }
        }
        private void CountProtection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            t = CountProtection.SelectedIndex + 3;
            CountProtection.IsEditable = false;
        }
    }
}
