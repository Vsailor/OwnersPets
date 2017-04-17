using System.ComponentModel.DataAnnotations;

namespace OwnersPets.Presentation.Models
{
    public class CreatePetRequest
    {
        public int OwnerId { get; set; }

        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of name")]
        public string PetName { get; set; }
    }
}