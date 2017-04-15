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

        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DatabaseFile);
        }

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

        public static void Main(string[] args)
        {
            while (true)
            {
                string qu = @"SELECT * FROM [Owner]";
                using (SQLiteConnection conn = SimpleDbConnection())
                {
                    conn.Open();
                    dynamic c = conn.Query<dynamic>(qu);
                }
            }

        }
    }
}
