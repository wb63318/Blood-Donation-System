using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_System.Models.Entities.BloodBank
{
    public class BloodBank
    {
        [Key]
        public Guid Id { get; set; }
        
        public string? hospitalName { get; set; } = string.Empty;
        public string? location { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public DateTime SignUpAt { get; set; }= DateTime.Now;
        public DateTime? ResetTokenExpires { get; set; }
        public string? PasswordResetToken { get; set; }
       /* public IEnumerable<Supply> Supplies { get; set; }
        public IEnumerable<BloodRequest> Requests { get; set; }*/
    }
}
