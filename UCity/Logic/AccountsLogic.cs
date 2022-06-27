using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Common.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UCity.Data.Dtos.Account;
using UCity.Data.Models.Auth;
using UCity.Data.Models.ServiceModels;
using UCity.Data.Repositories.AccountsRepository;
using BC = BCrypt.Net.BCrypt;

namespace UCity.Logic
{
    public class AccountsLogic : IAccountsLogic
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<AuthSettings> _authSettings;

        public AccountsLogic(IAccountsRepository accountsRepository, IMapper mapper, IOptions<AuthSettings> authSettings)
        {
            _accountsRepository = accountsRepository;
            _mapper = mapper;
            _authSettings = authSettings;
        }

        public async Task<AccountAuthenticateResponse> Authenticate(AccountAuthenticateRequest request)
        {
            var account = await _accountsRepository.GetAccountByEmail(request.Email);

            if (account == null || account.IsVerified || !BC.Verify(request.Password, account.PasswordHash))
                throw new AppException("Email or password is incorrect");

            var jwtToken = GenerateJwtToken(account);

            account = await _accountsRepository.Update(account);

            var accountReadDto = _mapper.Map<AccountReadDto>(account);
            return new AccountAuthenticateResponse
            {
                User = accountReadDto,
                AccessToken = jwtToken
            };
        }

        public async Task<AccountReadDto> Create(AccountCreateDto accountCreate)
        {
            if (await _accountsRepository.IsAccountExist(accountCreate.Email))
                throw new AppException($"Email '{accountCreate.Email}' is already registered");

            var account = _mapper.Map<Account>(accountCreate);
            account.Created = DateTime.UtcNow;
            account.PasswordHash = BC.HashPassword(accountCreate.Password);

            account = await _accountsRepository.Create(account);

            return _mapper.Map<AccountReadDto>(account);
        }

        public async Task Delete(int id)
        {
            await _accountsRepository.Delete(id);
        }

        public async Task<IEnumerable<AccountReadDto>> GetAll()
        {
            var accounts = await _accountsRepository.GetAll();

            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }

        private string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}