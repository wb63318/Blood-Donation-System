using Blood_Donation_System.Data;
using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_System.Repos.BloodBank.Repositories
{
    public class DonationRp : DonationInterface
    {
        private readonly DonationSystemDbContext _dbContext;

        public DonationRp(DonationSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Donation> AddAsync(Donation donation)
        {
            donation.Id = Guid.NewGuid();
            await _dbContext.Donations.AddAsync(donation);
            await _dbContext.SaveChangesAsync();
            return donation;
        }

        public async Task<Donation> DeleteAsync(Guid id)
        {
           var existingDonation = await _dbContext.Donations.FindAsync(id);
            if(existingDonation == null)
            {
                return null;
            }
            _dbContext.Donations.Remove(existingDonation);
            await _dbContext.SaveChangesAsync();
            return existingDonation;
        }

        public async Task<IEnumerable<Donation>> GetAllAsync()
        {
            return await _dbContext
                .Donations
                .ToListAsync();
        }

        public async Task<Donation> GetAsync(Guid id)
        {
            return await _dbContext
                .Donations
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Donation> GetByRecipientName(string recipientname)
        {
            return await _dbContext
                .Donations
                .FirstOrDefaultAsync(x => x.recipientName == recipientname);
        }

        public async Task<Donation> UpdateAsync(Guid id,Donation donation)
        {
            var existingDonation = await _dbContext.Donations.FindAsync(id);
            if(existingDonation != null)
            {
                existingDonation.donorName = donation.donorName;
                existingDonation.bloodGroup = donation.bloodGroup;
                existingDonation.quantity = donation.quantity;
                existingDonation.dateofDonation = donation.dateofDonation;
                existingDonation.recipientName = donation.recipientName;
                existingDonation.createdDate = donation.createdDate;
                await _dbContext.SaveChangesAsync();
                return existingDonation;
               
            }
            return null;
        }
    }
}
