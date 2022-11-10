using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class UpdateDonorRequest
    {
        public string? fullName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? email { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number not up to")]
        public string? phoneNumber { get; set; }
        public Group? bloodType { get; set; }
        public Gender gender { get; set; }
        public DateTime dateofBirth { get; set; }

        public string? location { get; set; }
        public DateTime? Updateddate { get; set; } = DateTime.Now;
    }
}
