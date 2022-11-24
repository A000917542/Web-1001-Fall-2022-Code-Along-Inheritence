using System.ComponentModel.DataAnnotations;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Models.Interfaces
{
    public interface IDbEmailIdentity
    {
        string? Email { get; set; }
    }
}
