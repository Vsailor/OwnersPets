using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using StorageModel.Data.Sql;
using Dapper;

namespace StorageModel.Data
{
    public class SimpleConnectionAdapter
    {
        /// <summary>
        /// Full database file path
        /// </summary>
        public static string DatabaseFile
        {
            get
            {
                string databasePath = ConfigurationManager.AppSettings["DatabasePath"];
                string fileName = "\\OwnersPetsDB.sqlite";

                if (string.IsNullOrEmpty(databasePath))
                {
                    return Environment.CurrentDirectory + fileName;
                }

                return databasePath + fileName;
            }
        }

        /// <summary>
        /// Creates SQLiteConnection object with connection string
        /// </summary>
        /// <returns>SQLiteConnection instance</returns>
        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DatabaseFile);
        }

        /// <summary>
        /// Creates database and seeds data for testing
        /// </summary>
        public static void CreateIfNotExistsDatabase()
        {
            if (File.Exists(DatabaseFile))
            {
                return;
            }

            using (SQLiteConnection conn = SimpleDbConnection())
            {
                conn.Open();
                conn.Execute(MigrationQuery.CreateDatabase);
                conn.Execute(MigrationQuery.SeedData);
            }
        }
    }
}
