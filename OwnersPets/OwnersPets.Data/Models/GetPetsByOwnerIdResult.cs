namespace OwnersPets.Data.Models
{
    public class GetPetsByOwnerIdResult
    {
        public int PetId { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }
    }
}
