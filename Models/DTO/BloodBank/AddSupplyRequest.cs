using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class AddSupplyRequest
    {
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public DateTime? supplyDate { get; set; }
    }
}
