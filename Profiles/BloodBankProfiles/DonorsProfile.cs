using AutoMapper;

namespace Blood_Donation_System.Profiles.BloodBankProfiles
{
    public class DonorsProfile :Profile
    {
        public DonorsProfile()
        {
            CreateMap<Models.Entities.BloodBank.Donor, Models.DTO.BloodBank.Donor>().ReverseMap();
        }
    }
}
