using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_4
{
    public partial class Club : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        static int IDClub = 1;
        static string ClubName = "No data";

        public Club()
        {
            InitializeComponent(); Clubs();
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

        void Clubs()
        {
            string a = "select IDClub as [№], ClubName as [Назва клубу]"
                + "from dbo.Club";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            ClubName = t2.Text;
            string a = "update dbo.Club" +
                       $" set ClubName = '{ClubName}'" +
                       $" where IDClub = {IDClub}";

            try { GD(a); Clubs(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            Clubs();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.Club where IDClub = {IDClub}";

            try { GD(a); Clubs(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.Club where IDClub = {t.Rows.Count}", connection);
            IDClub = (int)command.ExecuteScalar();
            connection.Close();

            string a = $"insert into dbo.Club values({IDClub + 1}, '{ClubName}')";

            try { GD(a); Clubs(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void t1up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { IDClub = int.Parse(t1.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t2up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { ClubName = t2.Text; }
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
