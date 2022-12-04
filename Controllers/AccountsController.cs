using AutoMapper;
using Blood_Donation_System.Data;
using Blood_Donation_System.Models.DTO.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Blood_Donation_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly DonationSystemDbContext _dbContext;

        public AccountsController(DonationSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("register")]
        public async Task<IActionResult>RegisterAsync(SignUpRequest signUp)
        {
            if (await _dbContext.BloodBanks.AnyAsync(u => u.Email == signUp.Email ))
            {
                return BadRequest("user exits");
            }
            CreatePasswordHash(signUp.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new BloodBank()
            {
               hospitalName = signUp.hospitalName,
               UserName = signUp.UserName,
               location = signUp.location,
               PhoneNumber = signUp.phoneNumber,
               Email = signUp.Email,
               PasswordHash = passwordHash,
               PasswordSalt = passwordSalt,
               SignUpAt = DateTime.UtcNow,

            };
            _dbContext.BloodBanks.Add(user);
            await _dbContext.SaveChangesAsync();
            return Ok("User Sucessfully Created!");
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _dbContext.BloodBanks.FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            
            if (!VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect");
            }
            return Ok($"Welcome back, {user.hospitalName}! :)");
        }
        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            var user = await _dbContext.BloodBanks.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return BadRequest("Invalid Detail");
            }
            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _dbContext.SaveChangesAsync();
            return Ok("You May Now Reset Your Password");
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.
                ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
