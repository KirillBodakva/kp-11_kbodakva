using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_4
{
    public partial class Breed : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;
            
        static int IDBreed = 1;
        static string BreedName = "No data";

        public Breed()
        {
            InitializeComponent(); Breeds();
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

        void Breeds()
        {
            string a = "select IDBreed as [№], BreedName as [Порода]"
                + "from dbo.Breeds";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            BreedName = t2.Text;
            string a = "update dbo.Breeds" +
                       $" set BreedName = '{BreedName}'" +
                       $" where IDBreed = {IDBreed}";

            try { GD(a); Breeds(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            Breeds();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.Breeds where IDBreed = {IDBreed}";

            try { GD(a); Breeds(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.Breeds where IDBreed = {t.Rows.Count}", connection);
            IDBreed = (int)command.ExecuteScalar();
            connection.Close();

            string a = $"insert into dbo.Breeds values({IDBreed + 1}, '{BreedName}')";

            try { GD(a); Breeds(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void t1up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { IDBreed = int.Parse(t1.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t2up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { BreedName = t2.Text; }
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
