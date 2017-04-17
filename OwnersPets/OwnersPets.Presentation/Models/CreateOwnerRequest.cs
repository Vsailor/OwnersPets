using System.ComponentModel.DataAnnotations;

namespace OwnersPets.Presentation.Models
{
    public class CreateOwnerRequest
    {
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of name")]
        public string OwnerName { get; set; }
    }
}