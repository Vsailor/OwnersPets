using System.Collections.Generic;

namespace OwnersPets.Model
{
    public class OwnerDetailedInfo
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }

        public IEnumerable<PetBasicInfo> Pets { get; set; }
    }
}
