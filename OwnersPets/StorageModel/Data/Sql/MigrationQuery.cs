namespace StorageModel.Data.Sql
{
    internal class MigrationQuery
    {
        public static string CreateDatabase
        {
            get
            {
                return @"
                CREATE TABLE Owner
                (
                    Name        VARCHAR(100) NOT NULL
                );

                CREATE TABLE Pet
                (
                    Name        VARCHAR(100) NOT NULL,
                    OwnerId     REFERENCES Owner(RowId) ON DELETE CASCADE
                );";
            }
        }

        public static string SeedData
        {
            get
            {
                return @"
                    INSERT INTO Owner (Name) VALUES ('Bob');
                    INSERT INTO Owner (Name) VALUES ('Simpson');
                    INSERT INTO Owner (Name) VALUES ('Michael');
                    INSERT INTO Owner (Name) VALUES ('Thomas');
                    INSERT INTO Owner (Name) VALUES ('Martin');
                    INSERT INTO Owner (Name) VALUES ('Diana');
                    INSERT INTO Owner (Name) VALUES ('Lili');
                    INSERT INTO Owner (Name) VALUES ('Chris');
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Snowball', 1);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Pet', 1);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Bulf', 1);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Rock', 1);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Luna', 2);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Han', 2);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Wolf', 2);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Doll', 2);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Lap', 3);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Stone', 3);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Rap', 3);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Crud', 3);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Tom', 4);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('West', 4);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Hit', 4);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Stack', 4);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Bim', 5);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Rex', 5);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Snake', 5);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('June', 5);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Loop', 6);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Rick', 6);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Roy', 6);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Sam', 6);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Roof', 7);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Temp', 7);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Rock', 7);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Rex', 8);
                    INSERT INTO Pet (Name, OwnerId) VALUES ('Dog', 8);
                ";
            }
        }
    }
}
