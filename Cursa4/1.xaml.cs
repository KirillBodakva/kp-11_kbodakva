using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Lab_4
{
    public partial class _1 : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t1 = new DataTable();
        static DataTable t2 = new DataTable();
        static DataTable t3 = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        
        public _1()
        {
            InitializeComponent(); Dogs(); Count(); Certificate();         
        }

        void GD1(string query)
        {
            t1.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(t1);
            d1.ItemsSource = t1.DefaultView;
            connection.Close();
        }

        void GD2(string query)
        {
            t2.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(t2);
            d2.ItemsSource = t2.DefaultView;
            connection.Close();
        }     

        void GD3(string query)
        {
            t3.Clear();
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(t3);
            d3.ItemsSource = t3.DefaultView;
            connection.Close();
        }

        void Dogs()
        {
            string dogs = "select IDDog as [№ собаки], Nickname as [Кличка собаки] from dbo.Dog";

            try { GD1(dogs); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Count()
        {
            string count = "select dbo.Breeds.BreedName as [Назва породи], COUNT(*) as [Кількість] "
                         + "from dbo.Dog INNER JOIN "
                         + "dbo.Breeds ON dbo.Dog.Breed = dbo.Breeds.IDBreed INNER JOIN "
                         + "dbo.Vystupy ON dbo.Dog.IDDog = dbo.Vystupy.IDDog "
                         + "GROUP BY dbo.Breeds.BreedName";

            try { GD2(count); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
}

        void Certificate()
        {
            
            string c = $"select * from dbo.Certificate1 ('{cb1.Text}', '{cb2.Text}')";

            try { GD3(c); }
            catch (Exception e2) { MessageBox.Show(e2.Message); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            string c = $"select * from dbo.Certificate1 ('{cb1.Text}', '{cb2.Text}')";

            try { GD3(c); }
            catch (Exception e2) { MessageBox.Show(e2.Message); }
        }
    }
}
