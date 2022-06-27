using UCity.Data.Models.Auth;

namespace UCity.Data.Repositories.AccountsRepository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AppDbContext _context;

        public AccountsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Create(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Account?> GetAccountByEmail(string email)
        {
            return await Task.Run(() => _context.Accounts.SingleOrDefault(x => x.Email.Equals(email, StringComparison.Ordinal)));
        }

        public async Task<bool> IsAccountExist(string email)
        {
            return await Task.Run(() => _context.Accounts.Any(a => a.Email.Equals(email, StringComparison.Ordinal)));
        }

        public async Task<Account> Update(Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await Task.Run(() => _context.Accounts.ToList());
        }

        public async Task Delete(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with provided id '{id}' not found");
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}