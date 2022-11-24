using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models.Base;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models.Interfaces;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Models
{
    public class ShoppingCart : DbEmailIdentity
    {
        [Required]
        [ForeignKey("Email")]
        public User User { get; set; } = new User();

        public ICollection<Product>? Products { get; set; }
    }
}
