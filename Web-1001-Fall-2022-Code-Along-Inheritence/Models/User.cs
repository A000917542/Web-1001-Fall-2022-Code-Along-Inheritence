using System.ComponentModel.DataAnnotations;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models.Base;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Models
{
    public class User : NameableEmailIdentity
    {
        public string? Address { get; set; }
    }
}
