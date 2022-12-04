using AutoMapper;
using Blood_Donation_System.Models.DTO.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;
using Blood_Donation_System.Repos.BloodBank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloodRequestsController : Controller
    {
        private readonly BloodRequestInterface _bloodRequest;
        private readonly IMapper _mapper;

        public BloodRequestsController(BloodRequestInterface bloodRequest , IMapper mapper)
        {
            _bloodRequest = bloodRequest;
            _mapper = mapper;
        }
        [HttpGet("{id:guid}")]
        [ActionName("GetBloodRequestAsync")]
        public async Task<IActionResult>GetBloodRequestAsync(Guid id)
        {
            var bRequest = await _bloodRequest.GetAsync(id);
            if(bRequest == null)
            {
                return NotFound();
            }
            var bRequestDto = _mapper.Map<Models.DTO.BloodBank.BloodRequest>(bRequest);
            return Ok(bRequestDto);
        }
        [HttpGet]
        public async Task <IActionResult> GetBloodRequestsAsync()
        {
            var bRequests = await _bloodRequest.GetAllAsync();
            var bRequestsDto = _mapper.Map<List<Models.DTO.BloodBank.BloodRequest>>(bRequests);
            return Ok(bRequestsDto);
        }
        [HttpPost]
        public async Task<IActionResult>AddBloodRequest(Models.DTO.BloodBank.AddBloodRequest bloodRequest)
        {
            var bRequest = new Models.Entities.BloodBank.BloodRequest()
            {
                bloodType = (Group)bloodRequest.bloodType,
                Quantity = bloodRequest.Quantity,
                requestType = (requestType)bloodRequest.requestType
            };
            bRequest = await _bloodRequest.AddAsync(bRequest);
            if(bRequest == null)
            {
                return NotFound();
            }
            var bRequestdto = new Models.DTO.BloodBank.BloodRequest
            {
                Id = bRequest.Id,
                bloodType = (Group)bRequest.bloodType,
                Quantity = (int)bRequest.Quantity,
                requestType = (requestType)bRequest.requestType
            };
            return CreatedAtAction(nameof(GetBloodRequestAsync), new {id = bRequestdto.Id}, bRequestdto);
        }
    }
}
