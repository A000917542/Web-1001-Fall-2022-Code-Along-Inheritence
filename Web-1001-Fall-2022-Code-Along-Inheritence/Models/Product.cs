using System.ComponentModel.DataAnnotations;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models.Base;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Models
{
    public class Product : Nameable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
    }
}