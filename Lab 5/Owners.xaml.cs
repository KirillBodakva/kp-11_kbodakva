using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Lab_4
{
    public partial class Owners : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        static int IDOwner = 1;
        static string OwnreName = "no data";
        static string OwnerSurname = "no data";
        static string OwnerSecName = "no data";
        static string Sex = "no data";
        static string OwnerDateBirth = "01.01.2003";
        static string OwnerPlaceBirth = "no data";

        public Owners()
        {
            InitializeComponent(); Ownerss();
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

        void Ownerss()
        {
            string a = "select IDOwner as [№], OwnreName as [Ім'я господаря],"
                + "OwnerSurname as [Прізвище], OwnerSecName as [По-батькові],"
                + "Sex as [Стать], OwnerDateBirth as [Дата народження],"
                + "OwnerPlaceBirth as [Місто народження]"
                + "from dbo.Owners";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            string a = "update dbo.Owners" +
                $" set OwnreName = '{OwnreName}'," +
                $" OwnerSurname = '{OwnerSurname}'," +
                $" OwnerSecName = '{OwnerSecName}'," +
                $" Sex = '{Sex}'," +
                $" OwnerDateBirth = '{OwnerDateBirth}'," +
                $" OwnerPlaceBirth = '{OwnerPlaceBirth}'" +
                $" where IDOwner = {IDOwner}";

            try { GD(a); Ownerss(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            Ownerss();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.Owners where IDOwner = {IDOwner}";

            try { GD(a); Ownerss(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.Owners where IDOwner = {t.Rows.Count}", connection);
            IDOwner = (int)command.ExecuteScalar();
            connection.Close();

            string a = $"insert into dbo.Owners values({IDOwner + 1}, '{OwnreName}', '{OwnerSurname}'," +
                $" '{OwnerSecName}', '{Sex}', '{OwnerDateBirth}', '{OwnerPlaceBirth}')";

            try { GD(a); Ownerss(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void t1up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { IDOwner = int.Parse(t1.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t2up(object sender, KeyEventArgs e)
        {
            if (t2.Text.Length > 0)
            {
                try { OwnreName = t2.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t3up(object sender, KeyEventArgs e)
        {
            if (t3.Text.Length > 0)
{
                try { OwnerSurname = t3.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t4up(object sender, KeyEventArgs e)
        {
            if (t4.Text.Length > 0)
            {
                try { OwnerSecName = t4.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t5up(object sender, KeyEventArgs e)
        {
            if (t5.Text.Length > 0)
            {
                try { Sex = t5.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }
        private void t6up(object sender, KeyEventArgs e)
        {
            if (t6.Text.Length > 0)
            {
                try { OwnerDateBirth = t6.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }
        private void t7up(object sender, KeyEventArgs e)
        {
            if (t7.Text.Length > 0)
            {
                try { OwnerPlaceBirth = t7.Text; }
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
