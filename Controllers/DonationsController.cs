using AutoMapper;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonationsController : Controller
    {
        private readonly DonationInterface _donation;
        private readonly IMapper _mapper;

        public DonationsController(DonationInterface donation, IMapper mapper)
        {
            _donation = donation;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDonationsAsync()
        {
            var donations = await _donation.GetAllAsync();
            var donationsDto = _mapper.Map<List<Models.DTO.BloodBank.Donation>>(donations);
            return Ok(donationsDto);
        }
        [HttpPost]
        public async Task<IActionResult>AddDonationAsync(Models.DTO.BloodBank.AddDonationRequest addDonation)
        {
            var donation = new Models.Entities.BloodBank.Donation()
            {
                donorName = addDonation.donorName,
                bloodGroup = (Group)addDonation.bloodGroup,
                quantity = addDonation.quantity,
                dateofDonation = addDonation.dateofDonation,
                recipientName = addDonation.recipientName,
                createdDate = addDonation.createdDate
            };
            var donationD = await _donation.AddAsync(donation);

            var donationDto = new Models.DTO.BloodBank.Donation()
            {
                Id = donation.Id,
                donorName = donation.donorName,
                bloodGroup = (Group)donation.bloodGroup,
                quantity = donation.quantity,
                dateofDonation = donation.dateofDonation, 
                recipientName = donation.recipientName, 
                createdDate = donation.createdDate
            };
            return CreatedAtAction(nameof(GetDonationAsync), new { id = donationDto.Id }, donationDto);
        }

        [HttpGet("{id:guid}")]
        [ActionName("GetDonationAsync")]
        public async Task<IActionResult>GetDonationAsync(Guid id)
        {
            var donation = await _donation.GetAsync(id);
            if (donation== null)
            {
                return BadRequest("No Content Found");
            }
            var donationDto = _mapper.Map<Models.DTO.BloodBank.Donation>(donation);
            return Ok(donationDto);
        }
    }
}
