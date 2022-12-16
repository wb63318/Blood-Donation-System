using Blood_Donation_System.Models.Entities.BloodBank;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface BloodRequestInterface
    {
        Task <IEnumerable<BloodRequest>> GetAllAsync();
        Task<BloodRequest> GetAsync(long id);
        Task<BloodRequest> AddAsync(BloodRequest bloodRequest);
    }
}
