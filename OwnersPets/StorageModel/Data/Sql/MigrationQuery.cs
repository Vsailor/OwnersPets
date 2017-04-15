namespace StorageModel.Data.Sql
{
    internal class MigrationQuery
    {
        public static string CreateDatabase
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

        public static string SeedData
        {
            get
            {
                return @"
                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (0, 'Bob');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (1, 'Simpson');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (2, 'Michael');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (3, 'Thomas');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (4, 'Martin');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (5, 'Diana');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (6, 'Lili');

                    INSERT INTO [Owner] (OwnerId, Name)
                    VALUES (7, 'Chris');

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (0, 'Snowball', 0);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (1, 'Pet', 0);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (2, 'Bulf', 0);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (3, 'Rock', 0);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (4, 'Luna', 1);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (5, 'Han', 1);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (6, 'Wolf', 1);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (7, 'Doll', 1);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (8, 'Lap', 2);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (9, 'Stone', 2);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (10, 'Rap', 2);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (11, 'Crud', 2);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (12, 'Tom', 3);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (13, 'West', 3);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (14, 'Hit', 3);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (15, 'Stack', 3);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (16, 'Bim', 4);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (17, 'Rex', 4);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (18, 'Snake', 4);

                    INSERT INTO [Pet] (PetId, Name, OwnerId)
                    VALUES (19, 'June', 4);
                ";
            }
        }
    }
}
