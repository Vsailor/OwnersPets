namespace StorageModel.Data.Sql
{
    internal class MigrationQuery
    {
        internal static string CreateDatabase
        {
            get
            {
                return @"
                CREATE TABLE [Owner]
                (
                    OwnerId     INTEGER IDENTITY PRIMARY KEY,
                    Name        VARCHAR(100) NOT NULL
                );


                CREATE TABLE Pet
                (
                    PetId       INTEGER IDENTITY PRIMARY KEY,
                    Name        VARCHAR(100) NOT NULL,
                    OwnerId     REFERENCES [Owner](OwnerId) ON DELETE CASCADE
                );";
            }
        }

        internal static string SeedData
        {
            get
            {
                return @"
                    INSERT INTO [Owner] (Name)
                    VALUES ('Bob');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Simpson');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Michael');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Thomas');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Martin');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Diana');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Lili');

                    INSERT INTO [Owner] (Name)
                    VALUES ('Chris');

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Snowball', 0);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Pet', 0);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Bulf', 0);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Rock', 0);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Luna', 1);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Han', 1);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Wolf', 1);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Doll', 1);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Lap', 2);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Stone', 2);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Rap', 2);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Crud', 2);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Tom', 3);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('West', 3);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Hit', 3);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Stack', 3);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Bim', 4);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Rex', 4);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('Snake', 4);

                    INSERT INTO [Pet] (Name, OwnerId)
                    VALUES ('June', 4);
                ";
            }
        }
    }
}
