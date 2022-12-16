using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class BloodRequest
    {
        [Key]
        public long Id { get; set; }
        public Group bloodType { get; set; }
        public int Quantity { get; set; }
        public requestType requestType { get; set; }
        /*
        public Guid HospitalId { get; set; }
        public BloodBank BloodBank { get; set; }*/
    }
}
