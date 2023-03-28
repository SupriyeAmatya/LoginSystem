using System.ComponentModel.DataAnnotations;

namespace Login.Data.DTO.Request
{
    public class TokenRefreshRequest
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
