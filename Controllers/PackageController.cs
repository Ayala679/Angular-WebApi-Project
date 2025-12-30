using Chinese_Auction.Dto_s;
using Chinese_Auction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinese_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPackages()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return Ok(packages);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageById(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null) return NotFound("Package with the given ID was not found");
            return Ok(package);
          
        }
        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] CreatePackageDto createPackageDto)
        {
            try
            {
                var newPackage = await _packageService.CreatePackageAsync(createPackageDto);
                return CreatedAtAction(nameof(GetPackageById), new { Id = newPackage.Id }, newPackage);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error occurred" + ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(int id, [FromBody] CreatePackageDto updatePackageDto)
        {
            try
            {
                var updatedPackage = await _packageService.UpdatePackageAsync(id, updatePackageDto);
                if (updatedPackage == null) return NotFound("Package with the given ID was not found");
                return Ok(updatePackageDto);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            try
            {
                var isDeleted = await _packageService.DeletePackageAsync(id);
                if (!isDeleted) return NotFound("Package with the given ID was not found");
                return Ok("deleted succesfully");
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error occurred" + ex.Message);
            }
        }
        
    }
}
