using AutoMapper;

namespace Blood_Donation_System.Profiles.BloodBankProfiles
{
    public class DonationsProfile :Profile
    {
        public DonationsProfile()
        {
            CreateMap<Models.Entities.BloodBank.Donation,Models.DTO.BloodBank.Donation>().ReverseMap();
        }
    }
}
