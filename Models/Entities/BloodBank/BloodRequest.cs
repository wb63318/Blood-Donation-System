using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.Entities.BloodBank
{
    public class BloodRequest
    {
        [Key]
        public Guid Id { get; set; }
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public requestType requestType { get; set; }
    }
}
