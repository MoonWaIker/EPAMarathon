namespace Marathon.Services.Models
{
    public class User
    {
        private readonly string name = string.Empty;
        public string Name
        {
            get => name;
            init
            {
                name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
            }
        }

        private readonly string lastname = string.Empty;
        public string Lastname
        {
            get => lastname;
            init
            {
                lastname = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
            }
        }

        private readonly string surname = string.Empty;
        public string Surname
        {
            get => surname;
            init
            {
                surname = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
            }
        }

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

        public DateOnly SignUpDate { get; set; }
    }
}
