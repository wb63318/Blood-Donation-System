using AutoMapper;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[Route("[controller]")]
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

        [HttpGet("{id:long}")]
        [ActionName("GetDonationAsync")]
        public async Task<IActionResult>GetDonationAsync(long id)
        {
            var donation = await _donation.GetAsync(id);
            if (donation== null)
            {
                return BadRequest("No Content Found");
            }
            var donationDto = _mapper.Map<Models.DTO.BloodBank.Donation>(donation);
            return Ok(donationDto);
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult>DeleteDonationAsync(long id)
        {
            var donation = await _donation.DeleteAsync(id);
            if(donation== null)
            {
                return BadRequest("Nothing to Delete");
            }
            var donationDto = new Models.DTO.BloodBank.Donation
            {
                Id = donation.Id,
                donorName = donation.donorName,
                bloodGroup = (Group)donation.bloodGroup,
                quantity = donation.quantity,
                dateofDonation = donation.dateofDonation,
                recipientName = donation.recipientName,
                createdDate = donation.createdDate,
            };
            return Ok(donationDto);
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateDonationAsync([FromRoute] long id , [FromRoute] Models.DTO.BloodBank.UpdateDonationRequest updateDonation)
        {
            var donation = new Models.Entities.BloodBank.Donation()
            {
                donorName = updateDonation.donorName,
                bloodGroup = (Group)updateDonation.bloodGroup,
                quantity = updateDonation.quantity,
                recipientName = updateDonation.recipientName,
                createdDate = updateDonation.updatedDate
            };
            donation = await _donation.UpdateAsync(id, donation);
            if (donation == null)
            {
                return NotFound();
            }
            var donationDto = new Models.DTO.BloodBank.Donation()
            {
                Id = donation.Id,
                donorName = donation.donorName,
                bloodGroup = donation.bloodGroup,
                quantity = donation.quantity,
                recipientName = donation.recipientName,
                createdDate = donation.createdDate,
            };
            return Ok(donationDto);
        }

    }
}
