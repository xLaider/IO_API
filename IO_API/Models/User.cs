namespace IO_API.Models
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Id { get; set; }
        public long Coins { get; set; }
        public long Score { get; set; }

    }
}
