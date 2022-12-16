using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface DonorInterface
    {
        Task<IEnumerable<Donor>> GetAllAsync();
        Task<Donor> GetByIdAsync(long id);
        Task<Donor> GetByNameAsync(string name);
        Task<Donor> AddAsync(Donor donor);
        Task<Donor> UpdateAsync(long id, Donor donor);
        Task<Donor> DeleteAsync(long id);

    }
}
