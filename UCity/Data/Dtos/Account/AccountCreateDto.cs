using System.ComponentModel.DataAnnotations;
using UCity.Data.Models.Auth;

namespace UCity.Data.Dtos.Account
{
    public class AccountCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}