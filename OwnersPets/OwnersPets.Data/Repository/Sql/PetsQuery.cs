namespace OwnersPets.Data.Repository.Sql
{
    internal class PetsQuery
    {
        public static string GetPetByPetIdCommand = @"
                    SELECT RowId,
	                       Name,
	                       OwnerId
                    FROM Pet    
                ";

        public const string GetPetsByOwnerIdCommand = @"
                    SELECT RowId,
	                       Name,
	                       OwnerId
                    FROM Pet
                    WHERE OwnerId = {0}
                    ORDER BY RowId DESC
                ";

        public const string DeletePetCommand = @"
                    DELETE FROM Pet WHERE RowId = {0};
                    DELETE FROM Owner WHERE OwnerId = {0};
                ";

        public const string CreatePetCommand = "INSERT INTO Pet (Name, OwnerId) VALUES ('{0}', {1})";
    }
}
