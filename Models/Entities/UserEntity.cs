namespace AnnonsApp.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}