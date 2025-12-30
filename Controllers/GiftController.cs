using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;
using Chinese_Auction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinese_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGifts()
        {
            var gifts = await _giftService.GetAllGiftsAsync();
            return Ok(gifts);
        }
        [HttpGet]
        [Route("un-approved")]
        public async Task<IActionResult> GetUnApprovedGiftsAsync()
        {
            var gifts = await _giftService.GetUnApprovedGiftsAsync();
            return Ok(gifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftByIdAsyncet(int id)
        {
            var gift = await _giftService.GetGiftByIdAsync(id);
            if (gift == null)
            {
                return NotFound("gift with the given ID was not found");
            }
            return Ok(gift);

        }

        [HttpPost]
        public async Task<IActionResult> CreateGiftAsync([FromBody] GiftDto gift)
        {
            try
            {
                var newGift = await _giftService.CreateGiftAsync(gift);
                return CreatedAtAction(nameof(GetGiftByIdAsyncet), new { Id = newGift.Id }, newGift);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error ocuured" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGiftAsync([FromBody] GiftDto gift,int id)
        {
            try
            {
                var updatedGift = await _giftService.UpdateGiftAsync(id,gift);
                if (updatedGift == null)
                {
                    return NotFound("gift with the given ID was not found");
                }
                return Ok(updatedGift);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error ocuured" + ex.Message);
            }

        }

        [HttpPut]
        [Route("purchase-quantity")]
        public async Task<IActionResult> UpdateGiftPurchasesQuantityAsync([FromBody] UpdateGiftDto giftPurchase,int id)
        {
            try
            {
                var updatedGift = await _giftService.UpdateGiftPurchasesQuantityAsync(id);
                if (updatedGift == null)
                {
                    return NotFound("gift with the given ID was not found");
                }
                return Ok(updatedGift);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error ocuured" + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiftAsync(int id)
        {
            var deleted = await _giftService.DeleteGiftAsync(id);
            if (!deleted)
            {
                return NotFound("gift with the given ID was not foundgift with the given ID was not found");
            }
            return Ok("deleted succesfully");
        }


    } 
}
