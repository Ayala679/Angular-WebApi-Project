using Chinese_Auction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinese_Auction.Dto_s
{
    public class CreateBasketDto
    {
        [Required]
        public int Gift_Id { get; set; }

        public int Cards_quantity { get; set; }

        [Required]
        public int User_Id { get; set; }

        [Required]
        public int Package_Id { get; set; }

        [Required]
        public string Unique_Package_Id { get; set; }
    }

    public class GetBasketDto
    {
        [Required]
        public int Gift_Id { get; set; }

        public int Cards_quantity { get; set; }

        [Required]
        public int Package_Id { get; set; }

        [Required]
        public string Unique_Package_Id { get; set; }
    }
}