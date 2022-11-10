using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_System.Data
{
    public class DonationSystemDbContext :DbContext
    {
        public DonationSystemDbContext(DbContextOptions<DonationSystemDbContext> options): base(options)
        {

        }
    }
}
