namespace OwnersPets.Data.Repository.Sql
{
    internal class OwnersQuery
    {
        public const string GetAllOwnersBasicInfoCommand = @"
                   SELECT Owner.RowId AS OwnerId, 
	                      Owner.Name AS Name, 
	                      (SELECT COUNT(*) FROM Pet WHERE Pet.OwnerId = Owner.RowId) AS PetsCount 
                   FROM Owner
                   ORDER BY Owner.RowId DESC
                ";

        public const string GetOwnerByOwnerIdCommand = @"
                    SELECT RowId, 
                           Name 
                    FROM Owner 
                    WHERE RowId = {0}
                ";

        public const string DeleteOwnerCommand = @"
                    DELETE FROM Owner WHERE RowId = {0};
                    DELETE FROM Pet WHERE OwnerId = {0};
                ";


        public const string CreateOwnerCommand = "INSERT INTO Owner (NAME) VALUES ('{0}')";
    }
}
