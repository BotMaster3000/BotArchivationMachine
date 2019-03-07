using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotArchivationMachine.Interfaces;
using System.Data.SQLite;
using System.IO;
using BotArchivationMachine.Models;

namespace BotArchivationMachine.Database
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly SQLiteConnection connection;
        public const string DATABASE_NAME = "ArchivationDataStorage.sqlite";
        private const string TABLE_NAME = "ArchivationInformation";

        public DatabaseManager()
        {
            if (!DatabaseExists())
            {
                CreateDataBase();
                connection = new SQLiteConnection(GetConnectionString());
                GenerateTables();
            }
            else
            {
                connection = new SQLiteConnection(GetConnectionString());
            }
        }

        private bool DatabaseExists()
        {
            return File.Exists(DATABASE_NAME);
        }

        private void CreateDataBase()
        {
            SQLiteConnection.CreateFile(DATABASE_NAME);
        }

        private string GetConnectionString()
        {
            return $"Data Source = {DATABASE_NAME};Version = 3;";
        }

        private void GenerateTables()
        {
            connection.Open();
            string tableSQL = $"CREATE TABLE {TABLE_NAME} (ID INT, Path VARCHAR, LastArchivingDate DATETIME, ArchivingIntervalInHours INT)";
            using (SQLiteCommand command = new SQLiteCommand(tableSQL, connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void AddEnty(IArchiveModel archive)
        {
            throw new NotImplementedException();
        }

        public List<IArchiveModel> GetAllEntries()
        {
            List<IArchiveModel> returnList = new List<IArchiveModel>();

            connection.Open();
            string sql = $"SELECT * FROM {TABLE_NAME}";
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new ArchiveModel()
                    {
                        ID = (int)reader["ID"],
                        Path = (string)reader["Path"],
                        LastArchivingDate = (DateTime)reader["LastArchivingDate"],
                        ArchivingIntervalInHours = (int)reader["ArchivingIntervalInHours"],
                    });
                }
            }
            connection.Close();

            return returnList;
        }

        public void RemoveEntry(IArchiveModel archive)
        {
            throw new NotImplementedException();
        }
    }
}
