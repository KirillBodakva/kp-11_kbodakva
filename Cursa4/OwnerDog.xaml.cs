﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_4
{
    public partial class OwnerDog : Window
    {
        string connectionString = MainWindow.connectionString;
        static DataTable t = new DataTable();
        SqlConnection connection = MainWindow.connection;
        SqlCommand command;
        SqlDataAdapter adapter;

        static int IDDog = 1;
        static int IDOwner = 1;

        public OwnerDog()
        {
            InitializeComponent(); OwnerDogs();
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

        void OwnerDogs()
        {
            string a = "select IDOwner as [№ господаря], IDDog as [№ собаки] from dbo.OwnerDog";
            try { GD(a); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Hide(); MainWindow.mw.Show();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            string a = $"update dbo.OwnerDog set IDOwner = {IDOwner} where IDDog = {IDDog}";
            try { GD(a); OwnerDogs(); }
            catch (Exception e2) { MessageBox.Show(e2.Message); }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            string a = $"delete from dbo.OwnerDog where IDDog = {IDDog}";
            try { GD(a); OwnerDogs(); }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            OwnerDogs();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            command = new SqlCommand($"select * from dbo.OwnerDog where IDDog = {t.Rows.Count}", connection);
            IDDog = (int)command.ExecuteScalar();
            connection.Close();
            string a = $"insert into dbo.DogClub values({IDDog + 1}, {IDOwner})"; // exchange

            try { GD(a); OwnerDogs(); }
            catch (Exception e2) { MessageBox.Show(e2.Message); }
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
                try { IDDog = int.Parse(t2.Text); }
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
