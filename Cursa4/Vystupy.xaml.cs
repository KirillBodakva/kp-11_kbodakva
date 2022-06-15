using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Lab_4
{
    public partial class Vystupy : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        static int IDDog = 1;
        static int IDMark = 1;
        static int IDExpert = 1;

        public Vystupy()
        {
            InitializeComponent(); Vy();
        }

        void GD(string query)
        {
            t.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(t);
            d1.ItemsSource = t.DefaultView;
            connection.Close();
        }

        void Vy()
        {
            string a = "select IDDog as [№ собаки], IDExpert as [№ експерта], "
                + "IDMark as [№ оцінки] from dbo.Vystupy";

            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            string a; 
            string b = "null";

            if (int.TryParse(t2.Text, out int c))
            {
                if (c > 0 && c < 4)
                {
                    b = c.ToString();
                }

            }
            a = "update dbo.Vystupy" +
                $" set IDMark = {b}," +
                $" IDExpert = {IDExpert}" +
                $" where IDDog = {IDDog}";

            try { GD(a); Vy(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            Vy();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.Vystupy where IDDog = {IDDog}";

            try { GD(a); Vy(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.Vystupy where IDDog = {t.Rows.Count}", connection);
            IDDog = (int)command.ExecuteScalar();
            connection.Close();
            string a;

            if(int.TryParse(t2.Text, out int c))
            {
                if(c > 0 && c < 4)
                {
                    a = $"insert into dbo.Vystupy values({IDDog + 1}, {t2.Text}, {IDExpert})";
                }
                else a = $"insert into dbo.Vystupy (IDDog, IDExpert) values({IDDog + 1}, {IDExpert})";
                
            }
            else a = $"insert into dbo.Vystupy (IDDog, IDExpert) values({IDDog + 1}, {IDExpert})";

            try { GD(a); Vy(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void t1up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { IDDog = int.Parse(t1.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t2up(object sender, KeyEventArgs e)
        {
            if (t2.Text.Length > 0)
            {
                try { IDMark = int.Parse(t2.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t3up(object sender, KeyEventArgs e)
        {
            if (t3.Text.Length > 0)
            {
                try { IDExpert = int.Parse(t3.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void td(object sender, MouseButtonEventArgs e)
        {
            var a = (TextBox)sender;
            a.Text = "";
        }
    }
}
