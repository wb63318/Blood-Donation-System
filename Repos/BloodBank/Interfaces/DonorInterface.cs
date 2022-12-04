using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface DonorInterface
    {
        Task<IEnumerable<Donor>> GetAllAsync();
        Task<Donor> GetByIdAsync(Guid id);
        Task<Donor> GetByNameAsync(string name);

        //Task<IEnumerable<Donor>> GroupByBloodtype();
        // Task<Donor> GetByBloodtype(Group bloodType);

        Task<Donor> AddAsync(Donor donor);
        Task<Donor> UpdateAsync(Guid id, Donor donor);
        Task<Donor> DeleteAsync(Guid id);

    }
}
