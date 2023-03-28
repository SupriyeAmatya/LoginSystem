using Login.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Login.Data.DTO.Request
{
    public class UserEditRequest
    {
        [Required(ErrorMessage = "Id is required.")]
        public string UserId { get; set; }
        public string FullName { get; init; } = string.Empty;
        public string UserName { get; init; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public int? ClientId { get; set; }
        public int? StaffId { get; set; }
        public string Role { get; init; } = string.Empty;
        public UserStatus UserStatus { get; init; } = UserStatus.Active;
    }
}
