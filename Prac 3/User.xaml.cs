using System.Linq;
using System.Windows;
using System.Data.SqlClient;
namespace Prac_3
{
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            string_connection = "Data Source = KIRILL; Initial Catalog = 3_prac; Integrated Security = True";
        }

        string string_connection = null;
        SqlConnection connection = null;
        SqlCommand command = null;
        static string login;
        static int counter = 0;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            ChangeName.IsEnabled = ChangeSurname.IsEnabled = ChangePass.IsEnabled = ChangeButt.IsEnabled = false;
            login = null;
        }

        public static bool IsPassword(string pass) => pass.Any(x => char.IsNumber(x)) && pass.Any(x =>
        char.IsUpper(x)) && pass.Any(x => char.IsLower(x));

        private void AddNewClick(object sender, RoutedEventArgs e)
        {

            if (Equals(NewLogin.Text, "") || Equals(NewPass.Text, ""))
            {
                MessageBox.Show("Треба заповнити усі поля");
                return;
            }
            if (!IsPassword(NewPass.Text))
            {
                MessageBox.Show("Не всі умови нормального пароля виконані");
                return;
            }
            try
            {
                connection = new SqlConnection(string_connection);
                connection.Open();

                string strQ = $"insert into MainTable values('{NewLogin.Text}', '{NewPass.Text}', '{NewName.Text}', '{NewSurname.Text}', 1);";
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
                NewPass.Text = NewName.Text = NewSurname.Text = NewLogin.Text = "";
                MessageBox.Show("Новий користувач зареєстрований");
            }
            catch
            {
                MessageBox.Show("Користувач з даним логіном вже інснує");
            }
            connection.Close();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {

            if (Equals(ChangePass.Text, ""))
            {
                MessageBox.Show("Введіть новий пароль користувача");
                return;
            }
            if (!IsPassword(ChangePass.Text))
            {
                MessageBox.Show("Не всі умови нормального пароля виконані");
                return;
            }
            connection = new SqlConnection(string_connection);
            connection.Open();

            string strQ = $"update MainTable set Password = '{ChangePass.Text}', Name = '{ChangeName.Text}'," +
                          $" Surname = '{ChangeSurname.Text}' where (dbo.MainTable.Login = '{login}') and (Status = 1);";
            command = new SqlCommand(strQ, connection);
            command.ExecuteNonQuery();
            ChangePass.Text = ChangeName.Text = ChangeSurname.Text = "";
            MessageBox.Show("Дані було оновлено");
            connection.Close();
        }

        private void AutoClick(object sender, RoutedEventArgs e)
        {
            if (Equals(UserLog.Text, ""))
            { MessageBox.Show("Введіть логін користувача"); return; }

            connection = new SqlConnection(string_connection);
            connection.Open();
            string strQ = $"select count(*) from MainTable where (dbo.MainTable.Login = '{UserLog.Text}') " +
                $"and (dbo.MainTable.Password = '{UserPass.Text}') and (Status = 1);";
            int amount = (int)new SqlCommand(strQ, connection).ExecuteScalar();
            if (amount != 0)
            {
                login = UserLog.Text;
                ChangeName.IsEnabled = ChangeSurname.IsEnabled = ChangePass.IsEnabled = ChangeButt.IsEnabled = true;
                UserLog.Text = UserPass.Text = "";
                counter = 0;
                MessageBox.Show("Ви авторизувались");
            }
            else if (counter < 3)
            {
                MessageBox.Show("Ви ввели некоректні дані");
                counter++;
            }
            else
            {
                MessageBox.Show("Ви ввели некоректні дані тричі");
                System.Windows.Application.Current.Shutdown();
            }
            connection.Close();
        }
    }
}
