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
        private const string ID_COLUMN_NAME = "ID";
        private const string PATH_COLUMN_NAME = "Path";
        private const string LASTARCHIVINGDATE_COLUMN_NAME = "LastArchivingDate";
        private const string ARCHIVINGINTERVALINHOURS_COLUMN_NAME = "ArchivingIntervalInHours";

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
            string tableSQL = $"CREATE TABLE {TABLE_NAME} "
                + $"({ID_COLUMN_NAME} INT NOT NULL, "
                + $"{PATH_COLUMN_NAME} VARCHAR NOT NULL, "
                + $"{LASTARCHIVINGDATE_COLUMN_NAME} DATETIME, "
                + $"{ARCHIVINGINTERVALINHOURS_COLUMN_NAME} INT NOT NULL, "
                + $"PRIMARY KEY({ID_COLUMN_NAME}))";
            using (SQLiteCommand command = new SQLiteCommand(tableSQL, connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void AddEnty(IArchiveModel archive)
        {
            connection.Open();

            string insertSQL = $"INSERT INTO {TABLE_NAME}"
                + $"({ID_COLUMN_NAME}, {PATH_COLUMN_NAME}, {LASTARCHIVINGDATE_COLUMN_NAME}, {ARCHIVINGINTERVALINHOURS_COLUMN_NAME})"
                + $"VALUES ('{archive.ID}', '{archive.Path}', '{archive.LastArchivingDate?.ToString("yyyy-MM-dd HH:mm:ss")}', '{archive.ArchivingIntervalInHours}')";

            using (SQLiteCommand command = new SQLiteCommand(insertSQL, connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        public List<IArchiveModel> GetAllEntries()
        {
            List<IArchiveModel> returnList = new List<IArchiveModel>();

            connection.Open();
            string selectSQL = $"SELECT * FROM {TABLE_NAME}";
            using (SQLiteCommand command = new SQLiteCommand(selectSQL, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new ArchiveModel()
                    {
                        ID = (int)reader[ID_COLUMN_NAME],
                        Path = (string)reader[PATH_COLUMN_NAME],
                        LastArchivingDate = (DateTime)reader[LASTARCHIVINGDATE_COLUMN_NAME],
                        ArchivingIntervalInHours = (int)reader[ARCHIVINGINTERVALINHOURS_COLUMN_NAME],
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
