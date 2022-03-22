using System.ComponentModel.DataAnnotations;

namespace IO_API.Auth
{
    public class LoginResponse
    {
        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }
        [Required(ErrorMessage = "UserID is required")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Token expiration date is required")]
        public DateTime TokenExpiration { get; set; }
    }
}
