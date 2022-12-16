using AutoMapper;
using Blood_Donation_System.Models.DTO.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank;
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
    public class SuppliesController : Controller
    {
        private readonly SupplyInterface _supply;
        private readonly IMapper _mapper;

        public SuppliesController(SupplyInterface supply , IMapper mapper)
        {
            _supply = supply;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliesAsync()
        {
            var supplies = await _supply.GetAllAsync();
            var suppliesDto = _mapper.Map<List<Models.DTO.BloodBank.Supply>>(supplies);
            return Ok(suppliesDto);

        }
        [HttpGet("{id:long}")]
        [ActionName("GetSupplyById")]
        public async Task<IActionResult> GetSupplyById(long id)
        {
            var supplyDomain = await _supply.GetAsync(id);

            var supplyDto = _mapper.Map<List<Models.DTO.BloodBank.Supply>>(supplyDomain);
            return Ok(supplyDto); 
        }

        [HttpPost]
       public async Task<IActionResult>AddSupplyAsync(Models.DTO.BloodBank.AddSupplyRequest addSupply)
        {
            var supply = new Models.Entities.BloodBank.Supply()
            {
                bloodType =(Group)addSupply.bloodType,
                Quantity = addSupply.Quantity,
                supplyDate = addSupply.supplyDate
            };
            supply = await _supply.AddAsync(supply);

            var supplyDto = new Models.DTO.BloodBank.Supply
            {
                Id = supply.Id,
                bloodType = (Group)supply.bloodType,
                Quantity = supply.Quantity,
                supplyDate = supply.supplyDate
            };
            return CreatedAtAction(nameof(GetSupplyById), new { id = supplyDto.Id }, supplyDto);
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateSuppyAsync([FromRoute] long id, [FromBody] Models.DTO.BloodBank.UpdateSupplyDetail updateSupply)
        {
            var supply = new Models.Entities.BloodBank.Supply()
            {
                bloodType = (Group)updateSupply.bloodType,
                Quantity = updateSupply.Quantity,
                supplyDate = updateSupply.supplyDate
            };
            var supplyDomain = await _supply.UpdateAsync(id, supply);
            if(supplyDomain == null)
            {
                return NotFound();
            }
            var supplyDto = new Models.DTO.BloodBank.Supply
            {
                Id = supply.Id,
                bloodType = (Group)supply.bloodType,
                Quantity = supply.Quantity,
                supplyDate = supply.supplyDate
            };
            return Ok(supplyDto);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult>DeleteSsupplyAsync(long id)
        {
            var supplyDomain = await _supply.DeleteAsync(id);
            if(supplyDomain == null)
            {
                return NotFound();
            }
            var supplyDto = _mapper.Map<Models.DTO.BloodBank.Supply>(supplyDomain);
            return Ok(supplyDto);
        }

       
    }
}
