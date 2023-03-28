using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Data.Models
{
    public class UserToken : ISoftDeletable
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [Key, Column(Order = 1)]
        public string UserRefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
