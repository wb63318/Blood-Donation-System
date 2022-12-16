using Blood_Donation_System.Repos.BloodBank.Interfaces;
using System.Security.Claims;

namespace Blood_Donation_System.Repos.BloodBank.Repositories
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetAccountName()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.GivenName);
                
            }
            return result;
        }
    }
}
