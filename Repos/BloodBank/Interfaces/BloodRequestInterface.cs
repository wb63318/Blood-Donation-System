using Blood_Donation_System.Models.Entities.BloodBank;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface BloodRequestInterface
    {
        Task<BloodRequest> GetAsync(Guid id);
        Task<BloodRequest> AddAsync(BloodRequest bloodRequest);
    }
}
