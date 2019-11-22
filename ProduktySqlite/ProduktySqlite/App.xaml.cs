using Mono.Data.Sqlite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProduktySqlite
{
    public partial class App : Application
    {
        private const string fileName = "databaze.db3";
        private readonly string dbPath;
        private readonly string connectionString;

        public App()
        {
            InitializeComponent();

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dbPath = Path.Combine(folder, fileName);
            connectionString = $"Data Source={dbPath}";

            MainPage = new NavigationPage(new View.ProduktyView(connectionString));
        }

        protected override void OnStart()
        {
            // File.Delete(dbPath);

            if (!File.Exists(dbPath))
            {
                SqliteConnection.CreateFile(dbPath);

                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = new SqliteCommand(connection))
                    {
                        command.CommandText = "CREATE TABLE produkt (produktId INTEGER PRIMARY KEY AUTOINCREMENT, nazev varchar(256), cena real)";
                        command.ExecuteNonQuery();
                    }

                    using (SqliteCommand command = new SqliteCommand(connection))
                    {
                        command.CommandText = "INSERT INTO produkt (nazev, cena) values (@nazev, @cena)";
                        command.Parameters.AddWithValue("@nazev", "mleko");
                        command.Parameters.AddWithValue("@cena", 19.90);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
