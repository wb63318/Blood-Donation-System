using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.DTO.BloodBank
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
