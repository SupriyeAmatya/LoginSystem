using Login.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Login.Data.DTO.Request
{
    public class UserRegisterRequest
    {
        [StringLength(100)]
        [Required]
        public string firstName { get; set; }

        [StringLength(100)]
        public string middleName { get; set; }

        [StringLength(100)]
        [Required]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        public UserType UserType { get; set; }

        // [Required]
        // public string Role { get; set; }
    }
}
