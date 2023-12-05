namespace Marathon.Services.Models
{
    public class User
    {
        // TODO should be better validation
        private readonly string email = string.Empty;
        public required string Email
        {
            get => email;
            init
            {
                email = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
            }
        }

        private readonly string password = string.Empty;
        public required string Password
        {
            get => password;
            init
            {
                password = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
            }
        }
    }
}
