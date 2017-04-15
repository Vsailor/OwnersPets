namespace OwnersPets.Presentation.Models
{
    public class CreatePetRequest
    {
        public int OwnerId { get; set; }

        public string PetName { get; set; }
    }
}