using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class AddDonationRequest
    {
        public string? donorName { get; set; }
        public Group bloodGroup { get; set; }
        public int quantity { get; set; }
        public DateTime dateofDonation { get; set; }
        public string? recipientName { get; set; }
        public DateTime createdDate { get; set; }
    }
}
