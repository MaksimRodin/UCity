namespace UCity.Data.Dtos.Account
{
    public class AccountAuthenticateResponse
    {
        public AccountReadDto User { get; set; }
        public string AccessToken { get; set; }
    }
}