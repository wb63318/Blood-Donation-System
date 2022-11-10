using AutoMapper;

namespace Blood_Donation_System.Profiles.BloodBankProfiles
{
    public class SuppliesProfile:Profile
    {
        public SuppliesProfile()
        {
            CreateMap<Models.Entities.BloodBank.Supply,Models.DTO.BloodBank.Supply>().ReverseMap();
        }
    }
}
