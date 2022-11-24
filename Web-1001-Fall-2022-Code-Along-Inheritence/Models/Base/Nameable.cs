using System.ComponentModel.DataAnnotations;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models.Interfaces;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Models.Base
{
    public abstract class Nameable : INameable
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string? Name { get; set; }
    }
}
