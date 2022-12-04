using Blood_Donation_System.Data;
using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_System.Repos.BloodBank.Repositories
{
    public class BloodRequestRp : BloodRequestInterface
    {
        private readonly DonationSystemDbContext _dbContext;

        public BloodRequestRp(DonationSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BloodRequest> AddAsync(BloodRequest bloodRequest)
        {
            bloodRequest.Id = Guid.NewGuid();
            await _dbContext.BloodRequests.AddAsync(bloodRequest);
            await _dbContext.SaveChangesAsync();
            return bloodRequest;
            
        }

        

        public Task<BloodRequest> GetAsync(Guid id)
        {
            return _dbContext
                .BloodRequests
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<BloodRequest>> GetAllAsync()
        {
            return await _dbContext.BloodRequests.ToListAsync();
        }
    }
}
