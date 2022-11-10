using Blood_Donation_System.Models.Entities.BloodBank;

namespace Blood_Donation_System.Repos.BloodBank.Interfaces
{
    public interface DonationInterface
    {
        Task<Donation> GetAsync(Guid id);
        Task<Donation> UpdateAsync(Guid id,Donation donation);
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation> AddAsync(Donation donation);
        Task<Donation> DeleteAsync(Guid id);
        Task<Donation>GetByRecipientName(string recipientname);
    }
}
