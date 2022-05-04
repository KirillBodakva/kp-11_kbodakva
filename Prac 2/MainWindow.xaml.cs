using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pract_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection pC = new PointCollection();
        Random rnd = new Random();

        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void InitPoints()
        {
           // Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75 * MainWin.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * MainWin.Height - 3 * Radius));
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el);
            }

        }
        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }

        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                if (i == 0)
                    EllipseArray[i].Fill = Brushes.Red;
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }
        private void PlotWay(int[] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);
            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }
        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
            ways = new List<int[]>();
            fill = false;
        }

        Boolean fill = false;
        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            if (mode.Text.Equals("Greedy"))
                PlotWay(GetBestWay());
            else
            {
                if (!fill)
                {
                    fill_ways();
                    fill = true;
                }
                PlotWay(GetBestWay_E());
            }
        }
        private int[] GetBestWay()
        {
            int[] indexes = new int[pC.Count];
            PointCollection available = pC.Clone();
            indexes[0] = 0;
            Point previous = available[0];
            available.RemoveAt(0);
            double topdistance; int topindex = 0;
            for (int index = 1; index < indexes.Length; index++)
            {
                topdistance = double.MaxValue;
                for (int i = 0; i < available.Count; i++)
                {
                    double currentdistance = Math.Sqrt(Math.Pow(previous.X - available[i].X, 2) + 
                                             Math.Pow(previous.Y - available[i].Y, 2));
                    if (currentdistance < topdistance)
                    {
                        topdistance = currentdistance;
                        topindex = pC.IndexOf(available[i]);
                    }
                }
                indexes[index] = topindex;
                available.Remove(pC[topindex]);
                previous = pC[topindex];
            }

            return indexes;
        }

        int populations = 15;
        List<int[]> ways = new List<int[]>();
        //Random rnd = new Random();
        String bruh = "";

        private void fill_row(int line)
        {
            List<int> available = new List<int>();
            for (int i = 0; i < pC.Count; i++)
                available.Add(i);
            for (int i = 0; i < pC.Count; i++)
            {
                int ind = rnd.Next(0, available.Count);
                ways[line][i] = available[ind];
                available.RemoveAt(ind);
            }
        }
        public void fill_ways()
        {
            for (int i = 0; i < 2 * populations; i++)
                ways.Add(new int[pC.Count]);
            for (int i = 0; i < populations; i++)
                fill_row(i);
            foreach (int[] t in ways)
            {
                foreach (int n in t)
                    bruh += n + "  ";
                bruh += "\n";
            }
        }
        class SortStruct
        {
            public int[] way; public double length;
            public SortStruct(int[] way)
            {
                this.way = way;
                length = GetLength_evolution(way);
            }
            private double GetLength_evolution(int[] sequence)
            {
                double total_length = 0;
                for (int i = 0; i < sequence.Length - 1; i++)
                {
                    total_length += Math.Sqrt(Math.Pow(pC[sequence[i]].X - pC[sequence[i + 1]].X, 2) +
                                    Math.Pow(pC[sequence[i]].Y - pC[sequence[i + 1]].Y, 2));
                }
                total_length += Math.Sqrt(Math.Pow(pC[sequence.Length - 1].X - pC[sequence[0]].X, 2) +
                                Math.Pow(pC[sequence.Last()].Y - pC[sequence.First()].Y, 2));
                return total_length;
            }
        }
        private int[] GetBestWay_E()
        {
            for (int repeatings = 0; repeatings < populations; repeatings++)
            {
                int i1 = rnd.Next(populations);
                int i2 = rnd.Next(populations);
                int cross_point = rnd.Next(2, pC.Count - 1);
                int[] temp1 = ways[i1][..cross_point].Union(ways[i2][cross_point..]).ToArray();
                int[] temp2 = ways[i2][..cross_point].Union(ways[i1][cross_point..]).ToArray();
                if (rnd.Next(0, 2) == 0)
                    ways[repeatings + populations] = temp1.Union(temp2).ToArray();
                else
                    ways[repeatings + populations] = temp2.Union(temp1).ToArray();
                if (rnd.NextDouble() < 0.7)
                {
                    i1 = rnd.Next(pC.Count);
                    i2 = rnd.Next(pC.Count);
                    if (i2 < i1)
                    {
                        int temp = i1;
                        i1 = i2;
                        i2 = temp;
                    }
                    int[] to_reverse = ways[repeatings + populations];
                    to_reverse = reverse(to_reverse, i1, i2);
                    ways[repeatings + populations] = to_reverse;
                }
            }
            List<SortStruct> structs = new List<SortStruct>();
            for (int i = 0; i < ways.Count; i++)
                structs.Add(new SortStruct(ways[i]));
            structs.Sort(delegate (SortStruct x, SortStruct y) {
                return x.length.CompareTo(y.length);
            });
            List<int[]> n_ways = new List<int[]>();
            for (int i = 0; i < structs.Count; i++)
                n_ways.Add(structs[i].way);
            ways = n_ways;
            return structs[0].way;
        }
        private int[] reverse(int[] arr, int i1, int i2)
        {
            int[] to_rev = arr[i1..i2];
            int[] tmp = to_rev.Reverse().ToArray();
            return arr[..i1].Concat(tmp).Concat(arr[i2..]).ToArray();
        }
    }

}
