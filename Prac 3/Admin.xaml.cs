using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace Prac_3
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            с = "Data Source = KIRILL; Initial Catalog = 3_prac; Integrated Security = True";
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Close(object sender, System.ComponentModel.CancelEventArgs e) =>
            System.Windows.Application.Current.Shutdown();

        string с = null;
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;
        DataTable d = null;

        static string password;
        int index = 0;
        int length = 0;

        private void DG()
        {
            connection = new SqlConnection(с);
            connection.Open();
            adapter = new SqlDataAdapter("select * from MainTable",connection);
            d = new DataTable("Список користувачів");
            adapter.Fill(d);
            output.ItemsSource = d.DefaultView;
            length = d.Rows.Count;
            connection.Close();
        }

        private void Checking()
        {
            int k = index;
            PCheck.Content = d.Rows[index][3].ToString();
            ICheck.Content = d.Rows[index][2].ToString();
            LogCheck.Content = d.Rows[index][0].ToString();
            if ((bool)d.Rows[index][4])
                StatCheck.Content = "Користувач активований";
            else StatCheck.Content = "Користувач деактивований";
            if (Equals(LogCheck.Content, "Admin"))
                StatChange.IsEnabled = false;
            else StatChange.IsEnabled = true;
        }

        private void ChangeUserStatus(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(с);
            connection.Open();
            int i;
            if (Equals(StatCheck.Content, "Користувач активований"))
            {
                StatCheck.Content = "Користувач деактивований";
                i = 0;
            }
            else
            {
                StatCheck.Content = "Користувач активований";
                i = 1;
            }
            string strQ = $"update MainTable set Status = '{i}' where (dbo.MainTable.Login = '{LogCheck.Content}')";
            command = new SqlCommand(strQ, connection);
            command.ExecuteNonQuery();
            DG();
            MessageBox.Show("Дані було оновлено");
            connection.Close();
        }

        private void ChangeAdminData(object sender, RoutedEventArgs e)
        {
            if (Equals(ChangePass.Text, "") || Equals(ChangeNewPass.Text, ""))
            { MessageBox.Show("Введіть новий пароль користувача"); return; }
            if (!Equals(ChangePass.Text, password))
            { MessageBox.Show("Старий пароль не є вірним"); return; }
            if (!User.IsPassword(ChangeNewPass.Text))
            { MessageBox.Show("Новий пароль не підходить під обмеження"); return; }
            connection = new SqlConnection(с);
            connection.Open();
            string strQ = $"update MainTable set Password = '{ChangeNewPass.Text}', " +
                          $"Name = '{ChangeName.Text}', Surname = '{ChangeSurname.Text}' where (dbo.MainTable.Login = 'ADMIN')";
            command = new SqlCommand(strQ, connection);
            command.ExecuteNonQuery();
            ChangePass.Text = ChangeNewPass.Text = ChangeName.Text = ChangeSurname.Text = "";
            DG();
            MessageBox.Show("Ви оновили дані");
            connection.Close();
        }

        private void NewUserByAdmin(object sender, RoutedEventArgs e)
        {
            if (Equals(AddLogin.Text, ""))
            { MessageBox.Show("Введіть логін"); return; }
            try
            {
                connection = new SqlConnection(с);
                connection.Open();
                string strQ = $"insert into MainTable values('{AddLogin.Text}', '', '', '', 1);";
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
                AddLogin.Text = "";
                DG();
                MessageBox.Show("Новий користувач зареєстрований");
            }
            catch
            { MessageBox.Show("Користувач з даним логіном вже інснує"); }
            connection.Close();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (Equals(AutoEnt.Text, ""))
            { MessageBox.Show("Введіть логін користувача"); return; }
            connection = new SqlConnection(с);
            connection.Open();
            string strQ = $"select count(*) from MainTable where (dbo.MainTable.Login = 'ADMIN') " +
                          $"and (dbo.MainTable.Password = '{AutoEnt.Text}');";
            int amount = (int)new SqlCommand(strQ, connection).ExecuteScalar();
            password = AutoEnt.Text;
            if (amount != 0)
            {
                ChangePass.IsEnabled = ChangeNewPass.IsEnabled = ChangeName.IsEnabled = ChangeSurname.IsEnabled = 
                ChangeUpdate.IsEnabled = Previous.IsEnabled = Next.IsEnabled = StatChange.IsEnabled = AddLogin.IsEnabled = 
                AddUser.IsEnabled = true;
                AutoEnt.Text = "";
                DG();
                Checking();
                MessageBox.Show("Ви авторизувались");
            }
            else MessageBox.Show("Ви ввели невірний пароль");
            connection.Close();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                Checking();
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < length - 1)
            {
                index++;
                Checking();
            }
        }
    }
}
