using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class BloodRequest
    {
        public Guid Id { get; set; }
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public requestType requestType { get; set; }
        public Guid DonorId { get; set; }
        public Donor Donor { get; set; }
    }
}
