using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinese_Auction.Models
{
    public class Basket
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Gift_Id { get; set; }

        [Required, ForeignKey("Gift_Id")]
        public Gift Gift { get; set; }

        public int Cards_quantity { get; set; }

        [Required]
        public int User_Id { get; set; }

        [Required, ForeignKey("User_Id")]
        public User User { get; set; }

        [Required]
        public int Package_Id { get; set; }
        [Required, ForeignKey("Package_Id")]
        public Package Package { get; set; }
        public string UniquePackageId { get; set; }

    }
}
