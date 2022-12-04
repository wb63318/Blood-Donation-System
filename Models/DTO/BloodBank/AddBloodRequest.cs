using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class AddBloodRequest
    {
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public requestType requestType { get; set; }
        /*public Guid DonorId { get; set; }
        public Donor Donor { get; set; }*/
    }
}
