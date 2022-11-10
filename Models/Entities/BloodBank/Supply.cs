using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.Entities.BloodBank
{
    public class Supply
    {
        [Key]
        public Guid Id { get; set; }
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public DateTime? supplyDate { get; set; }
        public supplyType Type { get; set; }
        public Guid HospitalId { get; set; }
        public BloodBank BloodBank { get; set; }

    }
    public enum supplyType
    {
        Incoming =1,
        Outgoing =2
    }
}
