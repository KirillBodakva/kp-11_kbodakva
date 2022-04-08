using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestNewWin
{
    class NewWin
    {
        static int M = 3;
        static int N = 4;
        public NewWin()
        {
            initControls();
        }

        private void initControls()
        {
            Window wn = new Window();
            wn.Title = "New Test Windows and Controls";
            wn.ResizeMode = ResizeMode.NoResize;
            
            Grid myGrid = new Grid();
            /*myGrid.Width = 400;
            myGrid.Height = 320;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;*/
            myGrid.ShowGridLines = true;

            Button[,] ArrBtn = new Button[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    ArrBtn[i, j] = new Button();
                    ArrBtn[i, j].Click += ArrBtn_Click;
                    ArrBtn[i, j].Content = "(" + (1 + i).ToString() + "; " + (1 + j).ToString() + ")";
                }

            RowDefinition[] rows = new RowDefinition[M];
            ColumnDefinition[] cols = new ColumnDefinition[N];
            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            for (int i = 0; i < M; i++)
            {
                rows[i] = new RowDefinition();
                rows[i].Height = (GridLength)gridLengthConverter.ConvertFrom(Convert.ToDouble(M/(i+1.0))+"*");
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < N; i++)
            {
                cols[i] = new ColumnDefinition();
                cols[i].Width = (GridLength)gridLengthConverter.ConvertFrom(Convert.ToDouble(N / (i + 1.0)) + "*");
                myGrid.ColumnDefinitions.Add(cols[i]);
            }

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(ArrBtn[i, j], i);
                    Grid.SetColumn(ArrBtn[i, j], j);
                }

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    myGrid.Children.Add(ArrBtn[i, j]);
                }

            /*for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    myGrid.Children.Remove(ArrBtn[i, j]);*/
            myGrid.Children.Remove(ArrBtn[0, 1]);
            myGrid.Children.Remove(ArrBtn[2, 2]);
            myGrid.Children.Remove(ArrBtn[1, 1]);
            myGrid.Children.Remove(ArrBtn[2, 0]);


            wn.Content = myGrid;
            wn.Show();
        }

        private void ArrBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show(btn.Content.ToString());
        }
    }
}
