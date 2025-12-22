using Chinese_Auction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinese_Auction.Dto_s
{
    public class CreatePurchaseDto
    {
        [Required]
        public int Gift_Id { get; set; }

        [Required,EmailAddress]
        public int User_Id { get; set; }

        [Required]
        public int Package_Id { get; set; }
        [Required]
        public string Unique_Package_Id { get; set; }

    }

    public class GetPurchaseDto
    {
        [Required]
        public int Gift_Id { get; set; }

        [Required]
        public int Package_Id { get; set; }

        [Required]
        public string Unique_Package_Id { get; set; }
    }
}