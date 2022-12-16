using AutoMapper;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Blood_Donation_System.Repos.BloodBank.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DonorsController : Controller
    {
        private readonly DonorInterface _donor;
        private readonly IMapper _mapper;

        public DonorsController(DonorInterface donor,IMapper mapper )
        {
           
            _donor = donor;
            _mapper = mapper;
        }
        [HttpGet("{id:long}")]
        [ActionName("GetDonorByIdAsync")]
        public async Task<IActionResult> GetDonorByIdAsync(long id)
        {
            var donor = await _donor.GetByIdAsync(id);
            if(donor == null)
            {
                return NotFound();
            }
            var donorDto = _mapper.Map<Models.DTO.BloodBank.Donor>(donor);
            return Ok(donorDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDonorsAsync()
        {
            var donors = await _donor.GetAllAsync();
            var donorsDto = _mapper.Map<List<Models.DTO.BloodBank.Donor>>(donors);
            return Ok(donorsDto);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetDonorByNameAsync(string name)
        {
            var donor = await _donor.GetByNameAsync(name);
            if (donor == null)
            {
                return NotFound();
            }
            var donorDto = _mapper.Map<Models.DTO.BloodBank.Donor>(donor);
            return Ok(donorDto);
        }
       
        
        [HttpPost]
        public async Task<IActionResult> AddDonorAsync(Models.DTO.BloodBank.AddDonorRequest addDonor)
        {
            var donor = new Models.Entities.BloodBank.Donor()
            {
                fullName = addDonor.fullName,
                email = addDonor.email,
                phoneNumber = addDonor.phoneNumber,
                gender = addDonor.gender,
                bloodType = addDonor.bloodType,
                dateofBirth = addDonor.dateofBirth,
                location = addDonor.location,
                Createddate = addDonor.Createddate
            };
            donor = await _donor.AddAsync(donor);

            var donorDto = new Models.DTO.BloodBank.Donor
            {
                Id = donor.Id,
                fullName = donor.fullName,
                email = donor.email,
                phoneNumber = donor.phoneNumber,
                gender = (Gender)donor.gender,
                dateofBirth = (DateTime)donor.dateofBirth,
                bloodType= donor.bloodType,
                location = donor.location,
                //Createddate = donor.Createddate

            };
            return CreatedAtAction(nameof(GetDonorByIdAsync) ,new { id = donorDto.Id }, donorDto);
        }
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateDonorDetailAsync([FromRoute] long id, [FromBody]Models.DTO.BloodBank.UpdateDonorRequest updateDonor)
        {
            var donor = new Models.Entities.BloodBank.Donor()
            {
                fullName = updateDonor.fullName,
                email = updateDonor.email,
                phoneNumber = updateDonor.phoneNumber,
                gender = (Gender)updateDonor.gender,
                bloodType = updateDonor.bloodType,
                dateofBirth = (DateTime)updateDonor.dateofBirth,
                location = updateDonor.location,
                Createddate = updateDonor.Updateddate
            };
            var donorDomain = await _donor.UpdateAsync(id, donor);
            if (donorDomain == null)
            {
                return NotFound();
            }

            var donorDto = new Models.DTO.BloodBank.Donor
            {
                Id = donor.Id,
                fullName = donor.fullName,
                email = donor.email,
                phoneNumber = donor.phoneNumber,
                gender = (Gender)donor.gender,
                dateofBirth = (DateTime)donor.dateofBirth,
                bloodType = donor.bloodType,
                location = donor.location,
                Createddate = donor.Createddate

            };
            return Ok(donorDto);
        }
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult>DeleteDonorAsync(long id)
        {
            var donor = await _donor.DeleteAsync(id);
            if(donor == null)
            {
                return Content("Donor does not Exist");
            }
            var donorDto = new Models.DTO.BloodBank.Donor
            {
                Id = donor.Id,
                fullName = donor.fullName,
                email = donor.email,
                phoneNumber = donor.phoneNumber,
                gender = (Gender)donor.gender,
                dateofBirth = (DateTime)donor.dateofBirth,
                bloodType = donor.bloodType,
                location = donor.location,
                Createddate = donor.Createddate
            };
            return Ok(donorDto);
        }
        
    }
}
