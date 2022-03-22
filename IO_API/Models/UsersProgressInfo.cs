using System.ComponentModel.DataAnnotations;

namespace IO_API.Models
{
    public class UsersProgressInfo
    {
        [Key]
        public string UserID { get; set; }
        public int Coins { get; set; }
        public int Population { get; set; }
    }
}
