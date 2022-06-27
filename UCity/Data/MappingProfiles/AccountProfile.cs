using AutoMapper;
using UCity.Data.Dtos.Account;
using UCity.Data.Models.Auth;

namespace UCity.Data.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountReadDto>();
            CreateMap<AccountCreateDto, Account>();
        }
    }
}