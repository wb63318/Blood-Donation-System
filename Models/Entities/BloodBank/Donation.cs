using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.Entities.BloodBank
{
    public class Donation
    {
        [Key]
        public long Id { get; set; }
        public string? donorName { get; set; }
        public Group bloodGroup { get; set; }
        public int quantity { get; set; }
        public DateTime dateofDonation { get; set; }
        public string? recipientName { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;

    }
    
}
