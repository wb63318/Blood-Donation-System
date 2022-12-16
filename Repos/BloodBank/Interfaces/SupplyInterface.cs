using Blood_Donation_System.Models.Entities.BloodBank;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface SupplyInterface
    {
        Task<IEnumerable<Supply>> GetAllAsync();
        Task<Supply> GetAsync(long id);
        Task<Supply> AddAsync(Supply supply);
        Task<Supply> UpdateAsync(long id,Supply supply);
        Task <Supply>DeleteAsync(long id);

    }
}
