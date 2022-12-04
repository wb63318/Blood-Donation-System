using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class UpdateDonationRequest
    {
        public string? donorName { get; set; }
        public Group bloodGroup { get; set; }
        public int quantity { get; set; }
        public string? recipientName { get; set; }
        public DateTime updatedDate { get; set; }
    }
}
