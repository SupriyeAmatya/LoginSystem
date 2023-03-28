using System.ComponentModel.DataAnnotations;
using Login.Data.Enum;
using Login.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.Data.Models;

public class AppUser : IdentityUser, ISoftDeletable
{
    [StringLength(100)]
    [Required]
    public string firstName { get; set; }

    [StringLength(100)]
    public string middleName { get; set; }

    [StringLength(100)]
    [Required]
    public string lastName { get; set; }

    [Required]
    public UserType UserType { get; set; }

    [Required]
    public UserStatus UserStatus { get; set; }
    public DateTime PasswordChangeDate { get; set; }

    [Required]
    public DateTime AccountCreatedDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public DateTime PwdExpiry { get; set; }
    public string ProfilePhoto { get; set; }
    public bool IsDeleted { get; set; } = false;
}
