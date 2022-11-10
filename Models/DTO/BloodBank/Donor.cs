using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class Donor
    {

        [Key]
        public Guid Id { get; set; }
        [RegularExpression("[a-zA-Z]", ErrorMessage = "Use letters only please")]
        [StringLength(30)]
        public string? fullName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? email { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number not up to")]
        public string? phoneNumber { get; set; }
        public Group? bloodType { get; set; }
        public Gender? gender { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "Date")]
        public DateTime? dateofBirth { get; set; }
        //public string? imagePath { get; set; }
        [RegularExpression("[a-zA-Z]", ErrorMessage = "Use letters only please")]
        public string? location { get; set; }
       // public IEnumerable<Donation>? Donations { get; set; }
        public DateTime? Createddate { get; set; } = DateTime.Now;
    }
}
