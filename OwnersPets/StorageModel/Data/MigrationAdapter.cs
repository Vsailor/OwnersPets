using System;
using System.Data.SQLite;
using System.IO;
using StorageModel.Data.Sql;
using Dapper;

namespace StorageModel.Data
{
    public class MigrationAdapter
    {
        public static string DatabaseFile
        {
            get { return Environment.CurrentDirectory + "\\OwnersPetsDB.sqlite"; }
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

        public static void Main(string[] arg)
        {
            CreateIfNotExistsDatabase();
        }
    }
}
