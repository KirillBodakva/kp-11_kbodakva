using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Data;
using Microsoft.SqlServer.Server;
using System.Data.Common;

namespace Lab_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DCon"].ConnectionString;
            Show();
        }

        private void ShowAll()
        {
            ComboBoxItem CB = (ComboBoxItem)cb.SelectedItem;
            string text = CB.Content.ToString();
            if (text == "Breeds") { Breeds(); }
            if (text == "Clubs") { Club(); }
            if (text == "Dogs") { Dog(); }
            if (text == "Experts") { Experts(); }
            if (text == "Medals") { Medal(); }
            if (text == "Owners") { Owners(); }
            if (text == "Performances") { Vystupy(); }
        }

        private void GD(string SQLQuerry)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuerry, connection);
            adapter = new SqlDataAdapter(command);
            DataTable t = new DataTable();
            adapter.Fill(t);
            dt.ItemsSource = t.DefaultView;
            dt.Columns[7] = new DataGridTextColumn()
            {
                Binding = new Binding((string)dt.Columns[7].Header)
                {
                    StringFormat = "yyyy.MM.dd"
                }
            };
            connection.Close();
        }

        void Breeds()
        {
            string a = "select IDBreed as [№], BreedName as [Порода]"
                + "from dbo.Breeds";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Club()
        {
            string a = "select IDClub as [№], ClubName as [Назва клубу]"
                + "from dbo.Club";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Dog()
        {
            string a = "select IDDog as [№], DogAge as [Вік],"
                + "NDocument as [Номер документу], Nickname as [Кличка],"
                + "NickMother as [Кличка мами], NickFather as [Кличка тата],"
                + "Breed as [№ породи], Vaccination as [Дата вакцинації]"
                + "from dbo.Dog";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Experts()
        {
            string a = "select IDExpert as [№], ExpertName as [Ім'я експерта],"
                + "ExpertSurname as [Прізвище експерта], IDClub as [№ клуба]"
                + "from dbo.Experts";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Medal()
        {
            string a = "select IDMedal as [№], Material as [Матеріал медалі]"
                + "from dbo.Medal";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Owners()
        {
            string a = "select IDOwner as [№], OwnreName as [Ім'я господаря],"
                + "OwnerSurname as [Прізвище], OwnerSecName as [По-батькові],"
                + "Sex as [Рід], OwnerDateBirth as [Дата народження],"
                + "OwnerPlaceBirth as [Місто народження]"
                + "from dbo.Owners";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void Vystupy()
        {
            string a = "select IDDog as [№ собаки], IDExpert as [№ експерта], "
                + "IDMark as [№ оцінки] from dbo.Vystupy";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
