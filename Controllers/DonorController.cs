using Chinese_Auction.Dto_s;
using Chinese_Auction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinese_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonors()
        {

            var donors = await _donorService.GetAllDonorsAsync();
            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {

            var donor = await _donorService.GetDonorByIdAsync(id);
            if (donor == null) return NotFound("donor with the given ID was not found");
            return Ok(donor);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateDonor([FromBody] CreateDonorDto donor)
        {
            try
            {
                var newDonor = await _donorService.CreateDonorAsync(donor);
                return CreatedAtAction(nameof(GetDonorById), new { id = newDonor.Id }, newDonor);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(int id, [FromBody] CreateDonorDto donor)
        {
            try
            {
                var updatedDonor = await _donorService.UpdateDonorAsync(id, donor);
                if (updatedDonor == null) return NotFound("donor with the given ID was not found");
                return Ok(updatedDonor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            
            var isDeleted = await _donorService.DeleteDonorAsync(id);
            if(!isDeleted) return NotFound("donor with the given ID was not found");
            return Ok("deleted succesfully");
        }

    }
}
