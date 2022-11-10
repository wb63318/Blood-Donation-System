using Blood_Donation_System.Data;
using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_System.Repos.BloodBank.Repositories
{
    public class SupplyRp : SupplyInterface
    {
        private readonly DonationSystemDbContext _dbContext;

        public SupplyRp(DonationSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Supply> AddAsync(Supply supply)
        {
           supply.Id = Guid.NewGuid();
            await _dbContext.Supplies.AddAsync(supply);
            await _dbContext.SaveChangesAsync();
            return supply;  
        }

        public async Task<Supply> DeleteAsync(Guid id)
        {
            var existingSupply = await _dbContext.Supplies.FindAsync(id);
            if(existingSupply == null)
            {
                return null;
            }
             _dbContext.Supplies.Remove(existingSupply);
            await _dbContext.SaveChangesAsync();
            return existingSupply;
        }

        public async Task<IEnumerable<Supply>> GetAllAsync()
        {
            return await _dbContext.Supplies
                .Include(x => x.BloodBank)
                .ToListAsync();
        }

        public async Task<Supply> GetAsync(Guid id)
        {
            return await _dbContext
                .Supplies
                .Include(x=>x.BloodBank)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Supply> UpdateAsync(Guid id, Supply supply)
        {
            var existingSupply = await _dbContext.Supplies.FindAsync(id);
            if(existingSupply != null)
            {
                existingSupply.bloodType = supply.bloodType;
                existingSupply.Quantity = supply.Quantity;
                existingSupply.supplyDate = supply.supplyDate;
                existingSupply.Type = supply.Type;
                existingSupply.HospitalId = supply.HospitalId;
                await _dbContext.SaveChangesAsync();
                return existingSupply;
            }
            return null;
        }
    }
}
