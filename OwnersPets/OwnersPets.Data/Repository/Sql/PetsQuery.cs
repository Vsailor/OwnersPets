namespace OwnersPets.Data.Repository.Sql
{
    internal class PetsQuery
    {
        public static string GetPetByPetIdCommand {
            get
            {
                return @"
                    SELECT PetId,
	                       Name,
	                       OwnerId
                    FROM Pet    
                ";
            }
        }

        public static string GetPetsByOwnerIdCommand
        {
            get
            {
                return @"
                    SELECT PetId,
	                       Name,
	                       OwnerId
                    FROM Pet
                    WHERE OwnerId = {0}    
                ";
            }
        }
    }
}
