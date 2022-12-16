using Blood_Donation_System.Data;
using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity;*/

namespace Blood_Donation_System.Repos.BloodBank.Repositories
{
    public class DonorRp : DonorInterface
    {
        private readonly DonationSystemDbContext _dbContext;

        public DonorRp(DonationSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Donor> AddAsync(Donor donor)
        {
           await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();
            return donor;
        }

        public async Task<Donor> DeleteAsync(long id)
        {
            var existingDonor = await _dbContext.Donors.FindAsync(id);
            if(existingDonor== null)
            {
                return null;
            }
             _dbContext.Remove(existingDonor);
            await _dbContext.SaveChangesAsync();
            return existingDonor;

        }

        public async Task<IEnumerable<Donor>> GetAllAsync()
        {
            return await _dbContext
                .Donors
                .ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(long id)
        {
            return await _dbContext
                .Donors
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Donor> GetByNameAsync(string name)
        {
            return await _dbContext
                .Donors
                .FirstOrDefaultAsync(x => x.fullName == name);
        }

       

        public async Task<Donor> UpdateAsync(long id, Donor donor)
        {
            var existingDonor = await _dbContext.Donors.FirstOrDefaultAsync(x => x.Id == id);
            if(existingDonor == null)
            {
                return null;
            }
           
            existingDonor.Id = donor.Id;
            existingDonor.fullName = donor.fullName;
            existingDonor.email = donor.email;
            existingDonor.gender = donor.gender;
            existingDonor.phoneNumber = donor.phoneNumber;
            existingDonor.location = donor.location;
            existingDonor.bloodType = donor.bloodType;
            existingDonor.dateofBirth = donor.dateofBirth;
            existingDonor.Createddate = donor.Createddate;
            _ = await _dbContext.SaveChangesAsync();
            return existingDonor;
        }

       
        


    }
}
