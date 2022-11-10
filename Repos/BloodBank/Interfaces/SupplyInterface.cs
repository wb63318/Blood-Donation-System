using Blood_Donation_System.Models.Entities.BloodBank;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface SupplyInterface
    {
        Task<IEnumerable<Supply>> GetAllAsync();
        Task<Supply> GetAsync(Guid id);
        Task<Supply> AddAsync(Supply supply);
        Task<Supply> UpdateAsync(Guid id,Supply supply);
        Task <Supply>DeleteAsync(Guid id);

    }
}
