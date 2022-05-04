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
using System.Diagnostics;

namespace Prj_Soft_Protection
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        List<TimeSpan> TimeSpanList = new List<TimeSpan>();
        bool start = false;
        int l = 0;
        bool validate = true;
        Stopwatch sw;

        public Window2()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            c.Text = "";
            TimeSpanList = new List<TimeSpan>();
            validate = true;
            start = false;
            l = 0;
        }
        public double Sum(int times, Func<int, double> f)
        {
            double res = 0;
            for (int i = 0; i < times; i++)
            {
                res += f(i);
            }
            return res;
        }
        int t = 0, pos = 0;
        public void Calculate(List<TimeSpan> TimeSpanList)
        {
            t++;
            double[] koef = { 6.314, 2.92, 2.353, 2.132, 2.015, 1.943,
                            1.895, 1.86, 1.833, 1.813, 1.8, 1.782, 1.761,
                            1.75, 1.75, 1.74, 1.734, 1.725, 1.72 };
            double M = Sum(TimeSpanList.Count, (j) => TimeSpanList[j].TotalSeconds) / TimeSpanList.Count;
            double D = Sum(TimeSpanList.Count, (j) => Math.Pow(TimeSpanList[j].TotalSeconds - M, 2) / (TimeSpanList.Count - 1));
            double[] savem = System.IO.File.ReadAllLines(@"D:\Visual Studio\\2 СЕМЕСТР\Prac 1\Prj_Soft_Protection\save.txt").Select(t => double.Parse(t.Split(' ')[0])).ToArray();
            double[] saves = System.IO.File.ReadAllLines(@"D:\Visual Studio\\2 СЕМЕСТР\Prac 1\Prj_Soft_Protection\save.txt").Select(t => double.Parse(t.Split(' ')[1])).ToArray();
            bool f
                = true;
            int n = 0;
            for (int i = 0; i < saves.Length; i++)
            {
                double F = Math.Max(saves[i], D) / Math.Min(saves[i], D);
                if (F < 3.18) { break; }
                double Sy = Sum(TimeSpanList.Count, (j) => Math.Pow(TimeSpanList[j].TotalSeconds - savem[i], 2)) / (TimeSpanList.Count - 1);
                double Sq = Math.Sqrt((Math.Pow(saves[i], 1) + Math.Pow(Sy, 1)) * (TimeSpanList.Count - 1) / (2 * TimeSpanList.Count - 1));
                double t = (saves[i] - M) / (Sq * Math.Sqrt(2 / TimeSpanList.Count));
                if (t < koef[TimeSpanList.Count - 2])
                {
                    n++;
                    f = false;
                }
            }
            if (!f) { pos++; }
            res.Content = (Math.Round((double)pos / (double)t * 100)).ToString() + "%" + $" {pos}/{t}";
            p1.Content = ((Math.Round((t - (double)pos) / (double)t * 100))).ToString() + "%";
            p2.Content = (Math.Round((double)n / ((double)saves.Length * t) * 100)).ToString() + "%";
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!validate)
            {
                validate = true;
                return;
            }
            if(c.Text.Length != 0 &&l > c.Text.Length || c.Text!= Window1.word.Substring(0, c.Text.Length))
            {
                MessageBox.Show("Error");
                Reset();
                return;
            }
            l = c.Text.Length;
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
                    TimeSpanList.Add(sw.Elapsed);
                    sw = new Stopwatch();
                    sw.Start();
                }
                if(c.Text == Window1.word)
                {
                    Calculate(TimeSpanList);
                    Reset();
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Hide();
        }
    }
}
