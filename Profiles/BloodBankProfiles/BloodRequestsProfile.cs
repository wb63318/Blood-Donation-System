using AutoMapper;

namespace Blood_Donation_System.Profiles.BloodBankProfiles
{
    public class BloodRequestsProfile: Profile
    {
        public BloodRequestsProfile()
        {
            CreateMap<Models.Entities.BloodBank.BloodRequest,Models.DTO.BloodBank.BloodRequest>().ReverseMap();
        }
    }
}
