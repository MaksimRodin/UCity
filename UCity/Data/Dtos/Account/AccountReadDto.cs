using UCity.Data.Models.Auth;

namespace UCity.Data.Dtos.Account
{
    public class AccountReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}