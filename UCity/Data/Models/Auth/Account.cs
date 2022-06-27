namespace UCity.Data.Models.Auth
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}