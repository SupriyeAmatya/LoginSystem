using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Login.Data.Enum;
using Login.Data.Models;

namespace Login.Data.DTO.Response
{
    [AutoMap(typeof(AppUser))]
    public class UserDataResponse
    {
        [SourceMember(nameof(AppUser.Id))]
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string CreatedBy { get; set; }
        public int UserStatus { get; set; } = 0;
        public bool EmailConfirmed { get; set; } = false;
        public DateTime PasswordChangeDate { get; set; } = DateTime.MinValue;
        public DateTime AccountCreatedDate { get; set; } = DateTime.MinValue;
        public DateTime ExpiryDate { get; set; } = DateTime.MinValue;
        public DateTime PwdExpiry { get; set; } = DateTime.MinValue;
        public string ClientName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public int? DepartmentId { get; set; } = null;
        public string Role { get; set; } = string.Empty;
        public int? ClientId { get; set; } = 0;
        public int? StaffId { get; set; }
    }
}
