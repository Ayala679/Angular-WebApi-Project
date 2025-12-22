using Chinese_Auction.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinese_Auction.Dto_s
{
    public class WinnerDto
    {
        public int User_Id { get; set; }

        [ForeignKey("User_Id"), Required]
        public User User { get; set; }

        [Required]
        public int Gift_Id { get; set; }

        [ForeignKey("Gift_Id"), Required]
        public Gift Gift { get; set; }
    }
}
