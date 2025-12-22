using System.ComponentModel.DataAnnotations;

namespace Chinese_Auction.Models
{
    public class Package
    {
        [Required]
        public int Id { get; set; }

        [Required,MaxLength(30)]
        public string Name { get; set; }

        [Required,MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int Cards_quantity { get; set; }

        [Required]
        public int Price { get; set; }
        public string Unique_Package_Id { get; set; }

    }
}
