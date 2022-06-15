using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4
{
    public partial class _2 : Window
    {
        SqlConnection connection = MainWindow.connection;
        public _2()
        {
            string connectionString = MainWindow.connectionString; 
            connection = new SqlConnection(MainWindow.connectionString);
            SqlCommand command;
            SqlDataAdapter adapter;


            InitializeComponent();          

            SetComboBoxItems("select BreedName from dbo.Breeds", cb1);
            SetComboBoxItems("select ClubName from dbo.Club", cb2);
            SetComboBoxItems("select concat(OwnreName + ' ', OwnerSurname) from dbo.Owners", cb3);
        }

        void SetComboBoxItems(string query, ComboBox cb)
        {         
            connection.Open();
            SqlCommand c = new SqlCommand(query, connection);
            SqlDataReader sqlReader = c.ExecuteReader();
                while (sqlReader.Read())
                    cb.Items.Add(sqlReader.GetString(0));
            connection.Close();
        }

        void GDTest(string query, DataGrid dg)
        {           
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void b1_Click_1(object sender, RoutedEventArgs e) =>
        GDTest($"select * from dbo.Get_Experts_by_Breed ('{cb1.Text}')", d1); 

        private void b2_Click(object sender, RoutedEventArgs e) =>
        GDTest($"select * from dbo.Get_Breeds_by_Club ('{cb2.Text}')", d2);

        private void b3_Click(object sender, RoutedEventArgs e) =>
        GDTest($"select * from dbo.Get_Medals_by_Club ('{cb2.Text}')", d2);

        private void b4_Click(object sender, RoutedEventArgs e)
        { Hide(); MainWindow.mw.Show(); }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            var v = cb3.Text.ToString().Split(' ');
            GDTest($"select * from dbo.Get_Vystupy ('{v[1]}', '{v[0]}')", d3);
        }
    }

    ///Які експерти обслуговують породу? +

    /*CREATE FUNCTION Get_Experts_by_Breed (@BreedName varchar(30))
        returns table
        return
                (
                    SELECT dbo.Experts.ExpertName AS [Ім'я], dbo.Experts.ExpertSurname AS Прізвище, dbo.Breeds.BreedName AS Порода
                        FROM dbo.Vystupy
                            INNER JOIN dbo.Experts ON dbo.Vystupy.IDExpert = dbo.Experts.IDExpert
                            INNER JOIN dbo.Dog ON dbo.Vystupy.IDDog = dbo.Dog.IDDog
                            INNER JOIN dbo.Breeds ON dbo.Dog.Breed = dbo.Breeds.IDBreed
                        WHERE (dbo.Breeds.BreedName = @BreedName)
                );
    */

    ///Якими породами предславлений заданий клуб?

    /*CREATE FUNCTION Get_Breeds_by_Club (@ClubName varchar(30))
        returns table
        return
                (
                    SELECT dbo.Breeds.BreedName AS Порода, dbo.Club.ClubName AS Клуб
                        FROM dbo.Breeds
                             INNER JOIN dbo.Dog ON dbo.Breeds.IDBreed = dbo.Dog.Breed
                             INNER JOIN dbo.DogClub ON dbo.Dog.IDDog = dbo.DogClub.IDDog
                             INNER JOIN dbo.Club ON dbo.DogClub.IDClub = dbo.Club.IDClub
                        WHERE (dbo.Club.ClubName = @ClubName)
                );
    */

    ///Які медалі та скільки заслужені клубом?

    /*CREATE FUNCTION Get_Medals_by_Club (@ClubName varchar(30))
        returns table
        return
                (
                    SELECT dbo.Medal.Material AS Медаль, dbo.Dog.Nickname AS [Кличка собаки], dbo.Club.ClubName AS Клуб
                    FROM dbo.Vystupy
                             INNER JOIN dbo.Medal ON dbo.Vystupy.IDMark = dbo.Medal.IDMedal
                             INNER JOIN dbo.Dog ON dbo.Vystupy.IDDog = dbo.Dog.IDDog
                             INNER JOIN dbo.DogClub ON dbo.Dog.IDDog = dbo.DogClub.IDDog
                             INNER JOIN dbo.Club ON dbo.DogClub.IDClub = dbo.Club.IDClub
                    WHERE (dbo.Club.ClubName = @ClubName)
                );
    */

    ///Виступ господаря з собакою?

    /*CREATE FUNCTION Get_Vystupy(@OwnerName varchar(50), @OwnerSurname varchar(50))
    returns table
    return
            (
                SELECT dbo.Dog.Nickname AS[Кличка собаки], dbo.Experts.ExpertSurname AS[Прізвище експерта],
                    dbo.Experts.ExpertName AS[Експерт по - батькові], ow.OwnerSurname AS[Ім'я господаря], 
                    ow.OwnerSecName AS[По - батькові], dbo.Medal.Material AS Медаль
                FROM dbo.Vystupy INNER JOIN
                    dbo.Dog ON dbo.Vystupy.IDDog = dbo.Dog.IDDog INNER JOIN
                    dbo.Experts ON dbo.Vystupy.IDExpert = dbo.Experts.IDExpert INNER JOIN
                    dbo.OwnerDog ON dbo.Dog.IDDog = dbo.OwnerDog.IDdog INNER JOIN
                    dbo.Owners as ow ON dbo.OwnerDog.IDOwner = ow.IDOwner LEFT JOIN
                    dbo.Medal ON dbo.Vystupy.IDMark = dbo.Medal.IDMedal
                WHERE(ow.OwnerSurname = @OwnerName and ow.OwnreName = @OwnerSurname)
            );
    */
}
