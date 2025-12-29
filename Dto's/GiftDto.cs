using Chinese_Auction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinese_Auction.Dto_s
{
    public class GiftDto
    {

        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        public string? Details { get; set; }

        [Required]
        public string picture { get; set; } = string.Empty;

        [Required]
        public int Donor_Id { get; set; }
        [Required]
        public string Category_Name { get; set; } = string.Empty;
        public bool isLottery { get; set; } = false;
    }



    public class UpdateGiftDto
    {
        public int Purchase_quantity { get; set; }
    }

}
