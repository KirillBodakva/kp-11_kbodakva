using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Lab_4
{
    public partial class Experts : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        static int IDExpert = 1;
        static string ExpertName = "No data";
        static string ExpertSurname = "No data";
        static int IDClub = 1;

        public Experts()
        {
            InitializeComponent(); Ex();
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

        void Ex()
        {
            string a = "select IDExpert as [№], ExpertSurname as [Прізвище експерта],"
                + "ExpertName as [Ім'я експерта], IDClub as [№ клуба]"
                + "from dbo.Experts";

            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            string a = "update dbo.Experts" +
                $" set ExpertName = '{ExpertName}'," +
                $" ExpertSurname = '{ExpertSurname}'," +
                $" IDClub = {IDClub}" +
                $" where IDExpert = {IDExpert}";

            try { GD(a); Ex(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            Ex();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.Experts where IDExpert = {IDExpert}";

            try { GD(a); Ex(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.Dog where IDDog = {t.Rows.Count}", connection);
            IDExpert = (int)command.ExecuteScalar();
            connection.Close();

            string a = $"insert into dbo.Experts values({IDExpert + 1}, '{ExpertName}', '{ExpertSurname}'," +
                $" '{IDClub}')";

            try { GD(a); Ex(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void t1up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { IDExpert = int.Parse(t1.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t2up(object sender, KeyEventArgs e)
        {
            if (t2.Text.Length > 0)
            {
                try { ExpertName = t2.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t3up(object sender, KeyEventArgs e)
        {
            if (t3.Text.Length > 0)
            {
                try { ExpertSurname = t3.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t4up(object sender, KeyEventArgs e)
        {
            if (t4.Text.Length > 0)
            {
                try { IDClub = int.Parse(t4.Text); }
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
