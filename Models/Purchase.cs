using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinese_Auction.Models
{
    public class Purchase
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Gift_Id { get; set; }
        [Required,ForeignKey("Gift_Id")]
        public Gift Gift { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required,ForeignKey("User_Id")]
        public User User { get; set; }
        [Required]
        public DateTime Purchase_Date { get; } = DateTime.Now;
    }
}
