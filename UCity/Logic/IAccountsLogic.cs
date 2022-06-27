using UCity.Data.Dtos.Account;

namespace UCity.Logic
{
    public interface IAccountsLogic
    {
        Task<AccountReadDto> Create(AccountCreateDto accountCreate);
        Task<AccountAuthenticateResponse> Authenticate(AccountAuthenticateRequest request);
        Task<IEnumerable<AccountReadDto>> GetAll();
        Task Delete(int id);
    }
}