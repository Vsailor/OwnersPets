namespace OwnersPets.Data.Repository.Sql
{
    internal class OwnersQuery
    {
        public static string GetAllOwnersBasicInfoCommand
        {
            get
            {
                return @"
                   SELECT [Owner].OwnerId AS OwnerId, 
	                      [Owner].Name AS Name, 
	                      (SELECT COUNT(*) FROM Pet WHERE Pet.OwnerId = [Owner].OwnerId) AS PetsCount 
                   FROM [Owner]
                ";
            }
        }

        public static string GetOwnerByOwnerIdCommand
        {
            get
            {
                return @"
                    SELECT OwnerId, 
                           Name 
                    FROM Owner 
                    WHERE OwnerId = {0}
                ";
            }
        }
    }
}
