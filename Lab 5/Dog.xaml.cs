using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_4
{
    public partial class Dog : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        static int IDDog = 1;
        static string DogAge = "1";
        static string NDocument = "No data";
        static string Nickname = "No data";
        static string NickMother = "No data";
        static string NickFather = "No data";
        static int Breed = 1;
        static string Vaccination = "01.01.2020";

        public Dog()
        {
            InitializeComponent(); Dogs();
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

        void Dogs()
        {
            string a = "select IDDog as [№], DogAge as [Вік],"
                + "NDocument as [Номер документу], Nickname as [Кличка],"
                + "NickMother as [Кличка мами], NickFather as [Кличка тата],"
                + "Breed as [№ породи], Vaccination as [Дата вакцинації]"
                + "from dbo.Dog";

            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            string a = "update dbo.Dog" +
                $" set DogAge = '{DogAge}'," +
                $" NDocument = '{NDocument}'," +
                $" Nickname = '{Nickname}'," +
                $" NickMother = '{NickMother}'," +
                $" NickFather = '{NickFather}'," +
                $" Breed = {Breed}," +
                $" Vaccination = '{Vaccination}'" +
                $" where IDDog = {IDDog}";

            try { GD(a); Dogs(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            Dogs();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.Dog where IDDog = {IDDog}";

            try { GD(a); Dogs(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.Dog where IDDog = {t.Rows.Count}", connection);
            IDDog = (int)command.ExecuteScalar();
            connection.Close();

            string a = $"insert into dbo.Dog values({IDDog + 1}, '{DogAge}', '{NDocument}'," +
                $" '{Nickname}', '{NickMother}', '{NickFather}', '{Breed}', '{Vaccination}')";

            try { GD(a); Dogs(); }
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
                try { DogAge = t2.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t3up(object sender, KeyEventArgs e)
        {
            if (t3.Text.Length > 0)
            {
                try { NDocument = t3.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t4up(object sender, KeyEventArgs e)
        {
            if (t4.Text.Length > 0)
            {
                try { Nickname = t4.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }

        private void t5up(object sender, KeyEventArgs e)
        {
            if (t5.Text.Length > 0)
            {
                try { NickMother = t5.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }
        private void t6up(object sender, KeyEventArgs e)
        {
            if (t6.Text.Length > 0)
            {
                try { NickFather = t6.Text; }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }
        private void t7up(object sender, KeyEventArgs e)
        {
            if (t7.Text.Length > 0)
            {
                try { Breed = int.Parse(t7.Text); }
                catch { MessageBox.Show("Неправильно введені дані!"); }
            }
        }
        private void t8up(object sender, KeyEventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                try { Vaccination = t8.Text; }
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
