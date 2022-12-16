using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Donation_System.Models.Entities.BloodBank
{
    public class BloodRequest
    {
        [Key]
        public long Id { get; set; }
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public requestType requestType { get; set; }
        /*[ForeignKey("BloodBank")]
        public Guid HospitalId { get; set; }
        public BloodBank BloodBank { get; set; }*/
    }
}
