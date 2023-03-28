using System.ComponentModel.DataAnnotations;

namespace Login.Data.DTO.Request
{
    public class CreateRoleRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
