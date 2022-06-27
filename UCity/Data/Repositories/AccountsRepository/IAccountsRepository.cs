using UCity.Data.Models.Auth;

namespace UCity.Data.Repositories.AccountsRepository
{
    public interface IAccountsRepository
    {
        Task<Account> Create(Account account);
        Task<bool> IsAccountExist(string email);
        Task<Account?> GetAccountByEmail(string email);
        Task<Account> Update(Account account);
        Task<IEnumerable<Account>> GetAll();
        Task Delete(int id);
    }
}