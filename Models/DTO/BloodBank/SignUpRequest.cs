using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class SignUpRequest

    {
        
        [Required]
        public string hospitalName { get; set; } =string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string phoneNumber { get; set; }
        public string location { get; set; }
        [Required,MinLength(7,ErrorMessage ="Password is too short")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? creationDate { get; set; }
        
    }
}
