using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Donation_System.Models.Entities.BloodBank
{
    public class Donor
    {
        [Key]
        public Guid Id { get; set; }
       
        public string? fullName { get; set; }
       
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public Group? bloodType { get; set; }
        public Gender? gender { get; set; }
        public DateTime? dateofBirth { get; set; }
        //public string? imagePath { get; set; }
        public string? location { get; set; }
        public IEnumerable<Donation>? Donations { get; set; }
        public DateTime? Createddate { get; set; } = DateTime.Now;
        

    }
}
