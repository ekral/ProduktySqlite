using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ProduktySqlite.ViewModel
{
    public class ProduktyViewModel
    {
        private readonly string connectionString;

        public ObservableCollection<Model.Produkt> Produkty { get; }

        public ProduktyViewModel(string connectionString)
        {
            this.connectionString = connectionString;

            Produkty = new ObservableCollection<Model.Produkt>();
        }

        public async Task NactiProdukty()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqliteCommand command = new SqliteCommand(connection))
                {
                    command.CommandText = "SELECT produktId, nazev, cena FROM produkt";

                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        long produktId = (long)reader["produktId"];
                        string nazev = (string)reader["nazev"];
                        float cena = (float)reader["cena"];

                        Model.Produkt produkt = new Model.Produkt(produktId, nazev, cena);
                        Produkty.Add(produkt);
                    }
                }

                connection.Close();
            }

        }
    }
}
